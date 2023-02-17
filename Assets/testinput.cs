using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testinput : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _jumpDuration = 3f;

    private Rigidbody2D rb;
    private PlayerInputActions controls;

    private float speed = 3;
    private float sprint = 2;
    private float horizontal;
    private float vertical;

    [SerializeField] bool _leJump = false;
    private bool _jeCours = false;
    private bool _jeTape = false;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _graphics = transform.Find("Graphics");
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_jeCours)
        {
            rb.velocity = new Vector2(horizontal * speed * sprint, vertical * speed * sprint);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        Jump2();
    }

    #endregion

    #region Methods

    public void Jump(InputAction.CallbackContext context)
    {
        _leJump = true;
    }

    public void Movement(InputAction.CallbackContext context)
    {
        SetVelocity(context.ReadValue<Vector2>());
        if (context.performed)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _jeCours = true;
            _animator.SetBool("isSprinting", true);
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _jeCours = false;
            _animator.SetBool("isSprinting", false);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _jeTape = true;
            _animator.SetBool("isSprinting", true);
            _animator.SetBool("isWalking", true);
        }
    }

    void SetVelocity(Vector2 _direction)
    {
        horizontal = _direction.x;
        vertical = _direction.y;
        flip();
    }

    void flip()
    {
        if (horizontal < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump2()
    {
        if (_leJump)
        {
            _isJumping = true;
            _animator.SetBool("isJumping", true);
        }
        if (_isJumping)
        {
            if (_jumpTimer < _jumpDuration)
            {
                _jumpTimer += Time.deltaTime;
                float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);
                _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);
            }
            else if (_jumpTimer >= _jumpDuration)
            {
                _jumpTimer = 0f;
                _isJumping = false;
                _animator.SetBool("isJumping", false);
            }
        }
        _leJump = false;
    }

    #endregion

    #region Private & Protected

    private UnityEngine.Transform _graphics;
    private float _jumpTimer;
    private bool _isJumping = false;
    private Animator _animator;

    #endregion

}


