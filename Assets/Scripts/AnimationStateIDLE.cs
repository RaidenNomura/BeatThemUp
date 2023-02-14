using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public enum State //should be at Base script instead of child
{
    IDLE,
    WALK,
    ATTACK
}

public class AnimationStateIDLE : MonoBehaviour //PROTO
{
    //PUBLIC AND EXPOSED

    //PRIVATE
    private Animator _animator;

    //LIFE CYCLE
    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("isIdle", true); //check name
        _animator.SetBool("isWalking", false);
        //etc
    }

    //METHOD
}
