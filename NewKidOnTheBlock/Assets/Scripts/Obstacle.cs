using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public virtual void HandleCollision(HealthManager healthManager)
    {
        Debug.Log("Obstacle Collision");
        HealthManager playerHealth = healthManager.GetComponentInChildren<HealthManager>();
        if (playerHealth != null)
        {
            Debug.Log("Player Health Found");
            playerHealth.TakeDamage(1);
        }
    }
}


