using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "obs")
        {
            Debug.Log("You Hurt Me");




}   }   }
