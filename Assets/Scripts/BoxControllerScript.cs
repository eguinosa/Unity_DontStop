using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class BoxControllerScript : MonoBehaviour
{

    private Rigidbody2D _rigidBody2D;
    private Animator _animator;

    public float maxSpeed = 10f;
    private bool facingRight;

    public float jumpForce = 800f;
    public Transform groundCheck;
    public Transform groundCheck2;
    public LayerMask whatIsGround;
    public bool godMode = false;

    private float _groundRadius = 0.2f;
    private bool _grounded = false;

    private bool _doubleJump = false;

    //Revive:
    private bool revive;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    //// Use this for initialization
    //void Start()
    //{
    //    _rigidBody2D = GetComponent<Rigidbody2D>();
    //    _animator = GetComponent<Animator>();
    //}

    // Update is called once per frame

    void FixedUpdate()
    {
        bool firstGround = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);
        bool secondGround = Physics2D.OverlapCircle(groundCheck2.position, _groundRadius, whatIsGround);

        _grounded = firstGround || secondGround;
        _animator.SetBool("Grounded", _grounded);
        _animator.SetFloat("VerticalSpeed", _rigidBody2D.velocity.y);

        if (_grounded)
        {
            _doubleJump = false;
            if(revive)
            {
                revive = !revive;
                HUDScript _hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
                _hud.Revive();
            }
        }

    }

    public void Move(float move, bool jump)
    {
        _animator.SetFloat("Speed", move);
        _rigidBody2D.velocity = new Vector2(move * maxSpeed, _rigidBody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if ((_grounded || !_doubleJump) && jump)
        {
            _animator.SetBool("Grounded", false);
            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, 0);
            _rigidBody2D.AddForce(new Vector2(0, jumpForce));
            if (!_grounded)
                _doubleJump = true;
        }
    }

    public void GetSave()
    {
        revive = true;
        transform.position = new Vector3(transform.position.x, transform.position.y + 3.3f);
        _rigidBody2D.velocity = new Vector2(0, 11);
        _doubleJump = false;
        Move(1f, false);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
