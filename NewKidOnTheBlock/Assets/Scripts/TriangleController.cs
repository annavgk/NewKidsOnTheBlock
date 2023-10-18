using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator anim;
    [HideInInspector] public bool active = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active == true)
        {
            Vector2 v = Physics2D.gravity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
        
        
    }

    public void activate()
    {
        active = true;
        controller.canJump = false;
        anim.SetBool("Triangle", true);
    }
    public void deactivate()
    {
        anim.SetBool("Triangle", false);
        active = false;
        Physics2D.gravity = new Vector2(0, -9.8f);
        Vector2 v = Physics2D.gravity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

}
