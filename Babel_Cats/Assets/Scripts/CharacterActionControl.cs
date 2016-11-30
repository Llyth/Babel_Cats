using UnityEngine;
using System.Collections;

public class CharacterActionControl : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float _jumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private float _dashForce = 400f;                  // Amount of force added when the player dash.
    [SerializeField] private bool _airControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask _whatIsGround;                  // A mask determining what is ground to the character

    private Transform _groundCheck;    // A position marking where to check if the player is grounded.
    const float _groundedRadius = .5f; // Radius of the overlap circle to determine if grounded
    private bool _grounded = false;            // Whether or not the player is grounded.
    private Transform _ceilingCheck;   // A position marking where to check for ceilings
    const float _ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up

    private Animator _anim;            // Reference to the player's animator component.

    private Rigidbody2D _rigidbody2D;
    private bool _facingRight = true;  // For determining which way the player is currently facing.

    private bool _doubleJump = true;

    private void Awake()
    {
        _groundCheck = transform.Find("GroundCheck");
        //        _ceilingCheck = transform.Find("CeilingCheck");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        _grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Platform")
            {
                _grounded = true;
                _airControl = false;
                _doubleJump = true;
            }
            if (colliders[i].gameObject.tag == "Floor")
            {
                _grounded = true;
                _airControl = false;
                _doubleJump = true;
            }
            else
                _airControl = true;

/*            if (colliders[i].gameObject.tag == "Player" && colliders[i].gameObject != gameObject)
            {
                _grounded = true;
                _doubleJump = true;
            }*/
        }
        _anim.SetBool("Ground", _grounded);
        _anim.SetFloat("vSpeed", _rigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    public void moveCharacter(float move, bool jump, bool dash)
    {
        if (_grounded || _airControl)
        {
            _rigidbody2D.velocity = new Vector2(move * _maxSpeed, _rigidbody2D.velocity.y);

            _anim.SetFloat("Speed", Mathf.Abs(move));
//            _anim.Play("KimonoCatRun");

            if (move > 0 && !_facingRight)
            {
                flipCharacterFacing();
            }
            else if (move < 0 && _facingRight)
            {
                flipCharacterFacing();
            }
        }

        if ((_grounded && jump) || (jump && _doubleJump))
        {
            if (_doubleJump)
                _rigidbody2D.AddForce(new Vector2(0f, _jumpForce - _rigidbody2D.velocity.y));
            else
                _rigidbody2D.AddForce(new Vector2(0f, _jumpForce));
            _grounded = false;
            _doubleJump = false;
        }

        if (dash)
        {
//            m_Grounded = false;
            if (_facingRight)
                _rigidbody2D.AddForce(new Vector2(_dashForce * 10, 0f));
            else
                _rigidbody2D.AddForce(new Vector2(-_dashForce * 10, 0f));
        }
    }


    private void flipCharacterFacing()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
