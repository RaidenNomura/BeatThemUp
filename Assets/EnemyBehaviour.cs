using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float _limitNearTarget = 1f;
    [SerializeField] private float _waitingTimeBeforeAttack = 1f;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _moveTarget = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (_playerDetected && !IsTargetNearLimit())
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget.position, Time.deltaTime);
        }
        if (IsTargetNearLimit())
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer >= _waitingTimeBeforeAttack)
            {
                _attackTimer = 0f;
            }
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

    bool IsTargetNearLimit()
    {
        return Vector2.Distance(transform.position, _moveTarget.position) < _limitNearTarget;
    }

    #endregion

    #region Private & Protected

    private bool _playerDetected = false;
    private Transform _moveTarget;
    private float _attackTimer;

    #endregion
}
