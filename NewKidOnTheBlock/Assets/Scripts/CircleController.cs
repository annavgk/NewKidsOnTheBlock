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
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private Animator anim;
    void Start()
    {
        original = rb.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float speed = Vector3.Magnitude(rb.velocity);  // test current object speed

        if (speed > maxVelocity)

        {
            Debug.Log(Vector3.Magnitude(rb.velocity));
            float brakeSpeed = speed - maxVelocity;  // calculate the speed decrease

            Vector2 normalisedVelocity = rb.velocity.normalized;
            Vector2 brakeVelocity = normalisedVelocity * (brakeSpeed * .25f);  // make the brake Vector3 value

            rb.AddForce(-brakeVelocity);  // apply opposing brake force
        }
        */
        Debug.Log(rb.velocity.sqrMagnitude);
        Debug.Log(maxVelocity);
        if (rb.velocity.sqrMagnitude > maxVelocity && active == true)
        {
            //Debug.Log(rb.velocity.sqrMagnitude);
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.75f;
        }
    }

    public void activate()
    {
        anim.SetBool("Circle", true);
        active = true;
        controller.canJump = false;
        rb.sharedMaterial = circlePhysics;
    }
    public void deactivate()
    {
        anim.SetBool("Circle", false);
        active = false;
        rb.sharedMaterial = original;
    }
}
