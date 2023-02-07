using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Exposed



    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _moveTarget = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, Time.deltaTime);
        }
    }

    #endregion

    #region Methods

    void PlayerDetected()
    {
        _playerDetected = true;
    }

    void PlayerEscaped()
    {
        _playerDetected = false;
    }

    #endregion

    #region Private & Protected

    private bool _playerDetected = false;
    private Transform _moveTarget;

    #endregion
}
