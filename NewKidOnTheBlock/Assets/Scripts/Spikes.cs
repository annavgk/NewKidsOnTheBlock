using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacle
{
    public int damageAmount = 2;

    public override void HandleCollision(HealthManager healthManager)
    {
        // Custom behavior for spikes
        // For example, spikes might deal more damage to the player
        HealthManager playerHealth = healthManager.GetComponentInChildren<HealthManager>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
