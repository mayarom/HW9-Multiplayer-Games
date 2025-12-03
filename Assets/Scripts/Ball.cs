using Fusion;
using UnityEngine;

/// <summary>
/// This component represents a ball moving at a constant speed.
/// It damages objects with a Health component and awards score
/// to the player who owns this ball (its input authority).
/// </summary>
public class Ball : NetworkBehaviour
{
    [Networked] private TickTimer lifeTimer { get; set; }

    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int damagePerHit = 1;

    public override void Spawned()
    {
        // Start life timer when the ball is spawned
        lifeTimer = TickTimer.CreateFromSeconds(Runner, lifeTime);
    }

    public override void FixedUpdateNetwork()
    {
        // Despawn the ball when its life time expires
        if (lifeTimer.Expired(Runner))
        {
            Runner.Despawn(Object);
        }
        else
        {
            // Move the ball forward at a constant speed
            transform.position += speed * transform.forward * Runner.DeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we hit has a Health component
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            // Deal damage to the target
            health.DealDamageRpc(damagePerHit);

            // Award score to the player who owns this ball (its input authority)
            if (Runner.TryGetPlayerObject(Object.InputAuthority, out NetworkObject playerObject))
            {
                Player shooter = playerObject.GetComponent<Player>();
                if (shooter != null)
                {
                    shooter.Score += 1;
                    Debug.Log($"Shooter scored! New score: {shooter.Score}");
                }
            }

            // Optionally you can despawn the ball immediately after a hit:
            // Runner.Despawn(Object);
        }
    }
}
