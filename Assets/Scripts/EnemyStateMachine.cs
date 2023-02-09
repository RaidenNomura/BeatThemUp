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
                _animator.SetBool("isMoving", true);
                break;
            case EnemyStateMode.ATTACK:
                _animator.SetBool("isAttacking", true);
                GetComponent<EnemyBehaviour>().isAttacking = false;
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
                _animator.SetBool("isMoving", false);
                break;
            case EnemyStateMode.ATTACK:
                _animator.SetBool("isAttacking", false);
                //Debug.Log("Value of is Attacking from EnemyScript" + GetComponent<EnemyBehaviour>().isAttacking);
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
                if(gameObject.transform.position != lastPos)
                {
                    //Debug.Log("IDLE to WALK cuz move detected");
                    TransitionToState(EnemyStateMode.WALK);
                }

                //ATTACK
                if(GetComponent<EnemyBehaviour>().isAttacking)
                {
                    TransitionToState(EnemyStateMode.ATTACK);
                }
                //HURT
                if(GetComponent<lifeManagement>().isHurting)
                {
                    TransitionToState(EnemyStateMode.HURT);
                }
                //DEAD
                //if(GetComponent<lifeManagement>().isDead)
                //{

                //}

                break;

            case EnemyStateMode.WALK:
                //should have condtition to go back Idle
                if (gameObject.transform.position == lastPos)
                {
                    //Debug.Log("WALK to IDLE cuz no move");
                    TransitionToState(EnemyStateMode.IDLE);
                }
                break;

            case EnemyStateMode.ATTACK: //on attack depuis la position idle
                //should add bool attack finish?
                GetComponent<EnemyBehaviour>().isAttacking = false;
                TransitionToState(EnemyStateMode.IDLE); //on retourne ensuite en idle
                break;

            case EnemyStateMode.HURT:
                if(GetComponent<lifeManagement>().isHurting == false)
                {
                    TransitionToState(EnemyStateMode.IDLE);
                }
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

    private void FixedUpdate()
    {
        lastPos= gameObject.transform.position; //dans le fix update il se synchro a un timming different de update state... 
    }

    #endregion


    #region Private & Protected

    private EnemyStateMode _currentState;
    private Animator _animator;
    private bool _isAttacking;
    private EnemyBehaviour _enemyBehaviour;
    Vector3 lastPos;

    #endregion
}
