using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _movementSmoothing = 0.5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    const float _groundCheckRadius = .01f;
    private bool _isGrounded;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector3 _velocity = Vector3.zero;
    [SerializeField]  private Rigidbody2D _rb;
    private bool _jumped;
    public float Speed = 40f;


    //[SerializeField] private Sprite square;
    //[SerializeField] private Sprite triangle;
    //[SerializeField] private Sprite circle;

    [SerializeField] private Sprite[] _sprites; //contains the sprites for each shape. will likely end up using a different method to swap shapes later
    private int _spriteCount = 0;//tracks the current sprite we are on








    void Start()
    {
        _spriteRenderer.sprite = _sprites[0];
    }

     void FixedUpdate() 
    {
        //creates circle collider that checks to see if any gameobjects within its radius are part of the ground layer and sets grounded to true if it does
		Collider2D collider = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        if(collider != null)
        {
            if (collider.gameObject != gameObject)
		    {
				_isGrounded = true;
		    }
            else
            {
                _isGrounded = false;
            }
        }
        else
        {
            _isGrounded = false;
        }
       
		
		Move((Input.GetAxisRaw("Horizontal") * Speed) * Time.fixedDeltaTime, _jumped);
        _jumped = false;
    }

    // Update is called once per frame
     void Update()
    {
        //creates circle collider that checks to see if any gameobjects within its radius are part of the ground layer and sets grounded to true if it does
        Collider2D collider = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        if (collider != null)
        {
            if (collider.gameObject != gameObject)
            {
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }
        }
        else
        {
            _isGrounded = false;
        }


        Move((Input.GetAxisRaw("Horizontal") * Speed) * Time.fixedDeltaTime, _jumped);
        _jumped = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
       {
        _jumped = true;
       }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapShape();
        }

    }

     public void Move(float move, bool jump)
     {
        Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);
        if(_isGrounded && jump)
        {
            _rb.AddForce(new Vector2(0f, _jumpForce));
          
        }	
        
     
        
      }
    private void SwapShape() //swaps the shape to the next in the list
    {
        if(_spriteCount < _sprites.Length)
        {
            _spriteRenderer.sprite = _sprites[_spriteCount];
            _spriteCount++;
        }
        else
        {
            _spriteCount = 0;
            _spriteRenderer.sprite = _sprites[_spriteCount];
        }
    }
      

  
    

}
     
    

