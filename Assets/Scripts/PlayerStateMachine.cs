using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

enum PlayerStateMode
{
    WALK,
    SPRINT,
    ATTACK
}


public class PlayerStateMachine : MonoBehaviour
{
    #region exposed

    #endregion


    #region Unity Lifecyle

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        TransitionToState(PlayerStateMode.WALK);
    }
    void Update()
    {
        OnStateUpdate();
    }
    #endregion

    #region Methode

    void OnStateEnter()
    {
        switch (_currentState)
        {
            case PlayerStateMode.WALK:
                break;
            case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", true);
                break;
            default:
                break;
        }
    }

    void OnStateExit()
    {
        switch (_currentState)
        {
            case PlayerStateMode.WALK:
                break;
            case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", false);
                break;
            default:
                break;
        }
    }

    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case PlayerStateMode.WALK:
                float dir_X = Input.GetAxis("Horizontal");
                float dir_Y = Input.GetAxis("Vertical");
                float moveSpeedXY = Mathf.Abs(dir_X) + Mathf.Abs(dir_Y);
                _animator.SetFloat("moveSpeed", moveSpeedXY); //check the name... maybe is MoveSpeedX
                //_animator.SetFloat("moveSpeed", Input.GetAxis("Vertical"));

                break;

            case PlayerStateMode.SPRINT:

                _animator.SetFloat("moveSpeed", Input.GetAxis("Horizontal")); //check the name... maybe is MoveSpeedX
                _animator.SetFloat("moveSpeed", Input.GetAxis("Vertical"));

                if (Input.GetButtonUp("Fire3"))
                {
                    TransitionToState(PlayerStateMode.WALK);
                }
                break;

            default:
                break;
        }
    }

    void TransitionToState(PlayerStateMode toState)
    {
        OnStateExit();
        _currentState = toState;
        OnStateEnter();
    }

    #endregion


    #region Private & Protected

    private PlayerStateMode _currentState;

    private Animator _animator;

    #endregion
}
