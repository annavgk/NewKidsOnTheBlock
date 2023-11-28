using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _jumpForce = 400f;
    [SerializeField] private float _movementSmoothing = 0.5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] TriangleController _triController;
    [SerializeField] CircleController _circController;
    const float _groundCheckRadius = .01f;
    private bool _isGrounded;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Vector3 _velocity = Vector3.zero;
    [SerializeField] private Rigidbody2D _rb;
    [HideInInspector] public bool _jumped;
    private string axis = "Horizontal";
    public float Speed = 40f;
    [HideInInspector] public bool canJump = true;
    [SerializeField] private Animator anim;


    

    [SerializeField] private Sprite[] _sprites; //contains the sprites for each shape. will likely end up using a different method to swap shapes later
    private int _spriteCount = 0;//tracks the current sprite we are on




    private void Awake()
    {
        Physics2D.gravity = new Vector2(0,-9.8f);
    }



    void Start()
    {
        _spriteRenderer.sprite = _sprites[0];
    }

    void FixedUpdate()
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

        if(Physics2D.gravity.y == 0f)
        {
            axis = "Vertical";
        }
        else
        {
            axis = "Horizontal";
        }


        Move((Input.GetAxisRaw(axis) * Speed) * Time.fixedDeltaTime, _jumped);
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


        Move((Input.GetAxisRaw(axis) * Speed) * Time.fixedDeltaTime, _jumped);
        _jumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
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
        if (Physics2D.gravity.y == 0f)   //changes controls when gravity pulls left or right
        {
            Vector3 targetVelocity = new Vector2(_rb.velocity.y, move * 10f);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);
        }
        else
        {
            Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);
            if (_isGrounded && jump)
            {
                anim.SetTrigger("Jump");
                AudioManager.Instance.PlayJump();
                _rb.AddForce(new Vector2(0f, _jumpForce));
                
            }
        }
       



    }
    private void SwapShape() //swaps the shape to the next in the list
    {
        AudioManager.Instance.PlaySwitch();
      //  _triController.deactivate();
       // _circController.deactivate();

        _spriteCount++;
        if (_spriteCount < _sprites.Length)
        {
            
            _spriteRenderer.sprite = _sprites[_spriteCount];
            
        }
        else
        {
            canJump = true;
            _spriteCount = 0;
            _spriteRenderer.sprite = _sprites[_spriteCount];
        }
        if(_spriteCount == 1)
        {
       //     _circController.activate();
        }
        else if (_spriteCount == 2)
        {
         //   _triController.activate();
        }


    }

}
