using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpingPower = 16f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator _anim;
    [SerializeField] private SquareController _square;
    [SerializeField] private TriangleController _triangle;
    private int _distanceFallen;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            _square.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _triangle.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if(!IsGrounded())
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
            if(_rb.velocity.y < 0)
            {
                Debug.Log("ghj");
                _distanceFallen++;
            }
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            if (_distanceFallen > 10)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
                _distanceFallen = 0;
            }
            else
            {
                _distanceFallen = 0;
            }
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);
    }
}
