using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _wallLayer;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _boxCollider;
    private float _wallJumpCooldown;
    private float _horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (_horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        else if (_horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.7f,0.7f,0.7f);

    
        _anim.SetBool("run", _horizontalInput != 0);
        _anim.SetBool("grounded", IsGrounded());

     
        if (_wallJumpCooldown > 0.2f)
        {
            _body.velocity = new Vector2(_horizontalInput * _speed, _body.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                _body.gravityScale = 0;
                _body.velocity = Vector2.zero;
            }
            else
                _body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            _wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            _body.velocity = new Vector2(_body.velocity.x, _jumpPower);
            _anim.SetTrigger("jump");
        }
        else if (OnWall() && !IsGrounded())
        {
            if (_horizontalInput == 0)
            {
                _body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x) * 0.7f, transform.localScale.y, transform.localScale.z);
            }
            else
                _body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            _wallJumpCooldown = 0;
        }
    }

   

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.1f, _groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, _wallLayer);
        return raycastHit.collider != null;
    }
}
