using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream:NewKidOnTheBlock/Assets/Scripts/Player_Health.cs

public class Player_Health : MonoBehaviour
=======
/// <summary>
/// Some feedback: 
/// 1.Even when changed, this still uses _ in the name. 
/// 2. When a player is hit, an event should be fired (Recall lecture on UnityEvents as well as what is required for Game Programming III assignment 1)
/// 3. Do not check for tags on game objects; instead you should be assigning, to spikes, a class. What if spikes need functionality? There should be an Obstacle class and then spikes should inherit from Obstacle. How the player interacts with different obstacle types should determine whether they are damaged, whether they are safe, etc.
/// 4. Your logic does not work even with the tags. I am going to write comments as to what it is actually doing
/// </summary>
public class PlayerHealth : MonoBehaviour
>>>>>>> Stashed changes:NewKidOnTheBlock/Assets/Scripts/PlayerHealth.cs
{
    public int health = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(health > 0)
        {
            if (collision.gameObject.CompareTag("obj"))
            {
                health--;
            }
            else
            {
                Debug.Log("You are Dead");

            }
        }

    }





}
