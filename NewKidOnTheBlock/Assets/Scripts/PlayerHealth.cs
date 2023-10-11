using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
