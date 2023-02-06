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
        if (Input.GetButton("Jump"))
        {
            if (_jumpTimer < _jumpDuration)
            {
                _jumpTimer += Time.deltaTime;
                float y = _jumpCurve.Evaluate(_jumpTimer / _jumpDuration);
                _graphics.localPosition = new Vector3(_graphics.localPosition.x, y * _jumpHeight, _graphics.localPosition.z);
            }
            else
            {
                _jumpTimer = 0f;
            }
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

    private Transform _graphics;
    private float _jumpTimer;

    #endregion
}
