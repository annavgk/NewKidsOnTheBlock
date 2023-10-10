using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Some feedback: 
/// 1.Even when changed, this still uses _ in the name. 
/// 2. When a player is hit, an event should be fired (Recall lecture on UnityEvents as well as what is required for Game Programming III assignment 1)
/// 3. Do not check for tags on game objects; instead you should be assigning, to spikes, a class. What if spikes need functionality? There should be an Obstacle class and then spikes should inherit from Obstacle. How the player interacts with different obstacle types should determine whether they are damaged, whether they are safe, etc.
/// 4. Your logic does not work even with the tags. I am going to write comments as to what it is actually doing
/// </summary>
public class Player_Health : MonoBehaviour
{
    public int health = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(health > 0) //this checks to see if the player's health is greater than 0. Question: why?
        {
            if (collision.gameObject.CompareTag("obj")) //this checks to see if the player has collided with something with the tag "obj". If they have, the player then loses....one health (this should be a variable and dependent on the type of thing they collide with; some will do small damage and some will kill the player)
            {
                health--;
            }
            else //this is the "else" for the check if the player collides with something that isn't a spike. your logic says that if they collide with spike, they lose health. if they collide with anything else, then you print out "You are Dead". Question: do you understand why this doesn't make sense?
            {
                Debug.Log("You are Dead");

            }
        }

    }





}
