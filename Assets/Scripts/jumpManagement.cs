using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] AnimationCurve _jumpCurve;

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

    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

    private Transform _graphics;
    private float _jumpTimer;

    #endregion
}
