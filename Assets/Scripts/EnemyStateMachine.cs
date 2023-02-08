using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Tilemaps;
using UnityEngine;

enum EnemyStateMode
{
    IDLE,
    WALK,
    ATTACK,
    DEATH,
    HURT

}


public class EnemyStateMachine : MonoBehaviour
{
    #region exposed

    #endregion


    #region Unity Lifecyle

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _isAttacking = GetComponent<EnemyBehaviour>().isAttacking;
    }

    void Start()
    {
        TransitionToState(EnemyStateMode.IDLE);
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
            case EnemyStateMode.IDLE:
                break;
            case EnemyStateMode.WALK:
                break;
            case EnemyStateMode.ATTACK:
                _animator.SetBool("isAttacking", true);
                break;
            case EnemyStateMode.HURT:
                _animator.SetBool("isHurting", true) ;
                break;
            default:
                break;
        }
    }

    void OnStateExit()
    {
        switch (_currentState)
        {
            case EnemyStateMode.IDLE:
                break;
            case EnemyStateMode.WALK:
                break;
            case EnemyStateMode.ATTACK:
                _animator.SetBool("isAttacking", false);
                GetComponent<EnemyBehaviour>().isAttacking = false; //pas sure que ca modify la valeur sur le scritp Enemy// override?
                break;
            case EnemyStateMode.HURT:
                _animator.SetBool("isHurting", false);
                break;
            default:
                break;
        }
    }

    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case EnemyStateMode.IDLE:

                //WALK
                //should have moveDetection with transform

                //ATTACK
                _isAttacking = GetComponent<EnemyBehaviour>().isAttacking;
                Debug.Log("Value of is Attacking = " + _isAttacking);
                if(_isAttacking)
                {
                    TransitionToState(EnemyStateMode.ATTACK);
                }
                //should have condition to attack player
                break;

            case EnemyStateMode.WALK:
                //should have condtition to go back Idle
                break;

            case EnemyStateMode.ATTACK: //on attack depuis la position idle
                //should add bool attack finish?
                TransitionToState(EnemyStateMode.IDLE); //on retourne ensuite en idle
                break;

            case EnemyStateMode.HURT:
                break;


            default:
                break;
        }
    }

    void TransitionToState(EnemyStateMode toState)
    {
        OnStateExit();
        _currentState = toState;
        OnStateEnter();
    }

    #endregion


    #region Private & Protected

    private EnemyStateMode _currentState;

    private Animator _animator;
    private bool _isAttacking;
    private EnemyBehaviour _enemyBehaviour;

    #endregion
}
