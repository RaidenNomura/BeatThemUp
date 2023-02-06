using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class movementManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] float _moveSpeed;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = _direction * Time.fixedDeltaTime * 50;
        //_direction.y = _rb2D.velocity.y;

        if (_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

    private Rigidbody2D _rb2D;
    private Vector2 _direction;

    #endregion

}
