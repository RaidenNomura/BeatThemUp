using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

enum PlayerStateMode
{
    IDLE,
    WALK,
    SPRINT,
    ATTACK,
    HIT,
    PICK
}


public class PlayerStateMachine : MonoBehaviour
{
    #region exposed

    [SerializeField] private GameObject _hitbox;

    #endregion

    #region Unity Lifecyle

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        TransitionToState(PlayerStateMode.IDLE);
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
            case PlayerStateMode.IDLE:
                break;
            case PlayerStateMode.WALK:
                break;
            case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", true);
                break;
            case PlayerStateMode.ATTACK:
                _animator.SetBool("isAttacking", true);
                break;
            case PlayerStateMode.HIT:
                _animator.SetBool("isHurting", true) ;
                break;
            case PlayerStateMode.PICK:
                _animator.SetBool("isPick", true);
                break;
            default:
                break;
        }
    }

    void OnStateExit()
    {
        switch (_currentState)
        {
            case PlayerStateMode.IDLE:
                break;
            case PlayerStateMode.WALK:
                break;
            case PlayerStateMode.SPRINT:
                _animator.SetBool("isSprinting", false);
                break;
            case PlayerStateMode.ATTACK:
                _animator.SetBool("isAttacking", false);
                break;
            case PlayerStateMode.HIT:
                _animator.SetBool("isHurting", false);
                break;
            case PlayerStateMode.PICK:
                _animator.SetBool("isPick", false);
                break;
            default:
                break;
        }
    }

    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case PlayerStateMode.IDLE:

                //WALK
                float moveSpeedXY = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
                _animator.SetFloat("moveSpeed", moveSpeedXY); 
                
                if(moveSpeedXY > 0.1f)
                {
                    TransitionToState(PlayerStateMode.WALK);
                }

                //ATTACK
                if (Input.GetButton("Fire1")) // en idle on peut attack
                {
                    _hitbox.SetActive(true);
                    TransitionToState(PlayerStateMode.ATTACK);
                }

                if (Input.GetKeyDown(KeyCode.C))
                {
                    Debug.Log("C is press");
                    TransitionToState(PlayerStateMode.PICK);
                }
                break;

            case PlayerStateMode.WALK:

                //float moveSpeedXY = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
                //_animator.SetFloat("moveSpeed", moveSpeedXY);

                if (Input.GetButton("Fire3")) //si on walk on peut sprint
                {
                    Debug.Log("X is press");
                    TransitionToState(PlayerStateMode.SPRINT);
                }


                moveSpeedXY = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
                if (moveSpeedXY == 0)
                {
                    TransitionToState(PlayerStateMode.IDLE);
                }


                break;

            case PlayerStateMode.SPRINT: //on suppose quon ne peut sprinter que si on WALK

                if (!Input.GetButton("Fire3")) //si on arrete de sprint on passe en walk
                {
                    Debug.Log("X release");
                    TransitionToState(PlayerStateMode.IDLE);
                }
                break;

            case PlayerStateMode.ATTACK: //on attack depuis la position idle

                if (!Input.GetButton("Fire1")) //on retourne en IDLE apres atk
                {
                    _hitbox.SetActive(false);
                    TransitionToState(PlayerStateMode.IDLE);
                }
                break;
            case PlayerStateMode.HIT:
                break;

            case PlayerStateMode.PICK:

                if (Input.GetKeyUp(KeyCode.C))
                {
                    Debug.Log("C is release");
                    TransitionToState(PlayerStateMode.IDLE);
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
