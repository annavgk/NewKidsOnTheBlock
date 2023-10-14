using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController controller;
    [HideInInspector] public bool active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void activate()
    {
        active = true;
        controller.canJump = false;
    }
    public void deactivate()
    {
        active = false;
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

}
