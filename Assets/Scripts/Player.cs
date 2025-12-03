using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private CharacterController _cc;

    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject ballPrefab;

    // Score for each player
    [Networked] public int Score { get; set; }

    // Boost system
    [Networked] private TickTimer BoostTimer { get; set; }
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float boostDuration = 1f;
    [SerializeField] private float boostCooldown = 2f;

    private Camera firstPersonCamera;
    private Vector3 moveDirection;

    public override void Spawned()
    {
        _cc = GetComponent<CharacterController>();

        // Attach camera only for local player
        if (HasStateAuthority)
        {
            firstPersonCamera = Camera.main;
            var cameraComponent = firstPersonCamera.GetComponent<FirstPersonCamera>();
            if (cameraComponent && cameraComponent.isActiveAndEnabled)
                cameraComponent.SetTarget(this.transform);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData inputData))
        {
            // Handle Boost
            float currentSpeed = speed;

            // Start boost if Shift pressed and timer is ready
            if (inputData.boostActionValue && BoostTimer.ExpiredOrNotRunning(Runner))
            {
                BoostTimer = TickTimer.CreateFromSeconds(Runner, boostDuration + boostCooldown);
            }

            // Apply boost only during active duration
            if (BoostTimer.IsRunning && BoostTimer.RemainingTime(Runner) > boostCooldown)
            {
                currentSpeed *= boostMultiplier;
            }

            // Movement
            if (inputData.moveActionValue.magnitude > 0)
            {
                inputData.moveActionValue.Normalize();
                moveDirection = new Vector3(inputData.moveActionValue.x, 0, inputData.moveActionValue.y);
                Vector3 delta = currentSpeed * moveDirection * Runner.DeltaTime;
                _cc.Move(delta);
            }

            // Shooting
            if (HasStateAuthority && inputData.shootActionValue)
            {
                Runner.Spawn(
                    ballPrefab,
                    transform.position + moveDirection,
                    Quaternion.LookRotation(moveDirection),
                    Object.InputAuthority
                );
            }
        }
    }
}
