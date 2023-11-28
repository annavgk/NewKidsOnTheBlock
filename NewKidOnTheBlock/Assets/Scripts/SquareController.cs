using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    private float _horizontal;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpingPower = 16f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator _anim;
    [SerializeField] private CircleController _circle;
    [SerializeField] private TriangleController _triangle;



    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _anim.SetTrigger("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && _rb.velocity.y > 0f)
        {
            
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.Z)) //swaps player object
        {
            _circle.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            _triangle.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);
    }
}
