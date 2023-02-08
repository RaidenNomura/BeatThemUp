using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;
    [SerializeField] float _jumpHeight = 3f;
    [SerializeField] float _jumpDuration = 3f;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _graphics = transform.Find("Graphics");
    }

    private void Start()
    {

    }


    private void Update()
    {
        jump();
    }

    #endregion

    #region Methods

    void jump()
    {
        if (Input.GetButton("Jump"))
            isJumping = true;
        if (isJumping)
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
                isJumping = false;
            }
        }
    }

    #endregion

    #region Private & Protected

    private Transform _graphics;
    private float _jumpTimer;
    private bool isJumping = false;

    #endregion
}
