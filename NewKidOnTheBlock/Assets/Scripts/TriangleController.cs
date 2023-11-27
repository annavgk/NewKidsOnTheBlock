using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    [SerializeField] private Transform Points;
    private float _horizontal;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    private bool _onPath;



    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 v = Physics2D.gravity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

    }

    private void FixedUpdate()
    {
        if(Physics2D.gravity.y == 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x ,_horizontal * _speed);
        }
        else
        {
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        }
        
    }

}
