// From the Fusion 2 Tutorial: https://doc.photonengine.com/fusion/current/tutorials/host-mode-basics/2-setting-up-a-scene#launching-fusion
using UnityEngine;
using Fusion;
using System.Collections.Generic;
using UnityEngine.InputSystem;

/// <summary>
/// This class launches the Fusion NetworkRunner (via EmptyLauncher)
/// and also spawns a new Player avatar whenever a player joins.
/// In addition, it gathers local input (movement, shoot, color, boost)
/// and sends it to Fusion each simulation tick.
/// </summary>
public class SpawningLauncher : EmptyLauncher
{
    [SerializeField] private NetworkPrefabRef _playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    // Keep a mapping between PlayerRef and the NetworkObject that represents their avatar.
    private readonly Dictionary<PlayerRef, NetworkObject> _spawnedCharacters =
        new Dictionary<PlayerRef, NetworkObject>();

    public override void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Player {player} joined");

        // Decide who is allowed to spawn player avatars
        bool isAllowedToSpawn =
            (runner.GameMode == GameMode.Shared)
                ? (player == runner.LocalPlayer)  // In Shared mode: only local player spawns
                : runner.IsServer;                // In Host/Server mode: only server spawns

        if (isAllowedToSpawn)
        {
            // Choose a spawn point based on the player's index
            Vector3 spawnPosition = spawnPoints[player.AsIndex % spawnPoints.Length].position;

            // Spawn the player avatar with input authority assigned to this player
            NetworkObject networkPlayerObject =
                runner.Spawn(_playerPrefab, spawnPosition, Quaternion.identity, player);

            // Track the spawned avatar
            _spawnedCharacters.Add(player, networkPlayerObject);
        }
    }

    public override void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Player {player} left");

        // Despawn and remove the avatar of this player
        if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            _spawnedCharacters.Remove(player);
        }
    }

    // === INPUT COLLECTION SECTION ===

    // Movement (2D vector: up/down/left/right)
    [SerializeField] private InputAction moveAction = new InputAction(type: InputActionType.Button);

    // Shoot (space key)
    [SerializeField] private InputAction shootAction = new InputAction(type: InputActionType.Button);

    // Color change (C key)
    [SerializeField] private InputAction colorAction = new InputAction(type: InputActionType.Button);

    // NEW: Boost (Left Shift)
    [SerializeField] private InputAction boostAction = new InputAction(type: InputActionType.Button);

    private void OnEnable()
    {
        moveAction.Enable();
        shootAction.Enable();
        colorAction.Enable();
        boostAction.Enable(); // enable boost input
    }

    private void OnDisable()
    {
        moveAction.Disable();
        shootAction.Disable();
        colorAction.Disable();
        boostAction.Disable(); // disable boost input
    }

    private void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261

        // Movement: 2D vector on arrow keys
        if (moveAction.bindings.Count == 0)
        {
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");
        }

        // Shoot: space bar
        if (shootAction.bindings.Count == 0)
        {
            shootAction.AddBinding("<Keyboard>/space");
        }

        // Color change: C key
        if (colorAction.bindings.Count == 0)
        {
            colorAction.AddBinding("<Keyboard>/C");
        }

        // NEW: Boost: Left Shift
        if (boostAction.bindings.Count == 0)
        {
            boostAction.AddBinding("<Keyboard>/leftShift");
        }
    }

    // This struct instance is filled each frame and then sent to Fusion in OnInput.
    private NetworkInputData inputData = new NetworkInputData();

    private void Update()
    {
        // Button-like inputs are sampled in Update, then converted to "one-frame flags"

        if (shootAction.WasPressedThisFrame())
        {
            inputData.shootActionValue = true;
        }

        if (colorAction.WasPressedThisFrame())
        {
            inputData.colorActionValue = true;
        }

        // NEW: Boost pressed this frame
        if (boostAction.WasPressedThisFrame())
        {
            inputData.boostActionValue = true;
        }
    }

    /// <summary>
    /// Called by Fusion before each simulation tick.
    /// Here we send the accumulated inputData to the network.
    /// </summary>
    public override void OnInput(NetworkRunner runner, NetworkInput input)
    {
        // Continuous input (movement) is read here
        inputData.moveActionValue = moveAction.ReadValue<Vector2>();

        // Send the struct by value to Fusion
        input.Set(inputData);

        // Reset button flags so they will be "one-frame" pulses
        inputData.shootActionValue = false;
        inputData.colorActionValue = false;
        inputData.boostActionValue = false;
    }
}
