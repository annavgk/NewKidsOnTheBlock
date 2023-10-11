<<<<<<< Updated upstream:NewKidOnTheBlock/Assets/Scripts/Player_Controller.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _movementSmoothing = 0.5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    const float _groundCheckRadius = .2f;
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
        
       if(Input.GetKeyDown(KeyCode.Space))
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
     
    

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sean Feedback:
/// 1. Make sure that you do not use _ in class names. Follow C# naming conventions. This should be PlayerController
/// 2. This class is good, but there should be separate classes or objects for the Square, Triangle, and Circle. You do not want to have all of the logic in this one class. They are three separate objects that all inherit from PlayerController. They will also have different physics rules as well, so having them all have the exact same RigidBody is an issue. 
/// 3. Why are you creating a collider on each update instead of just making a collider? You do not want to create a new collider every frame; that's extremely inefficient. You can have multiple colliders on an object.
/// 4. Have rough code done for all 3 object types, as well as switching logic, done ASAP. This should have been implemented by the 11th, as having it at least working in some 
/// 
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _movementSmoothing = 0.5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    const float _groundCheckRadius = .2f;
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
        
       if(Input.GetKeyDown(KeyCode.Space))
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
     
    

>>>>>>> Stashed changes:NewKidOnTheBlock/Assets/Scripts/PlayerController.cs
