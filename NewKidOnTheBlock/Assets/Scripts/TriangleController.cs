using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private SquareController _square;
    [SerializeField] private CircleController _circle;

    

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 v = Physics2D.gravity;  //changes rotation depending on gravity
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.X)) //swaps player object
        {
            _square.transform.position = transform.position;
            _circle.transform.position = transform.position;
            _circle.gameObject.SetActive(true);
            Physics2D.gravity = new Vector2(0, -9.8f);
            gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _square.transform.position = transform.position;
            _circle.transform.position = transform.position;
            _square.gameObject.SetActive(true);
            Physics2D.gravity = new Vector2(0, -9.8f);
            gameObject.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        if(Physics2D.gravity.y == 0)
        {
           _rb.velocity = new Vector2(_rb.velocity.x , Input.GetAxisRaw("Vertical") * _speed);
        }
        else
        {
           _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        }

     
       
       


        
    }

}
