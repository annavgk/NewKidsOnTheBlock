using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController controller;
    [HideInInspector] public bool active = false;
    [SerializeField]  private Rigidbody2D rb;
    private PhysicsMaterial2D original;
    [SerializeField] private PhysicsMaterial2D circlePhysics;
    void Start()
    {
        original = rb.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void activate()
    {
        active = true;
        controller.canJump = false;
        rb.sharedMaterial = circlePhysics;
    }
    public void deactivate()
    {
        active = false;
        rb.sharedMaterial = original;
    }
}
