using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] private int _maxLifePoint = 100;
    [SerializeField] private int _lifePoint;
    [SerializeField] private int _damageValue = 10;
    [SerializeField] private GameObject _gameObject;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _lifePoint = _maxLifePoint;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    #endregion

    #region Collisions

    // Collision avec l'ennemmi : on décrémente les points de vie du joueur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyHand") && _gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            _lifePoint -= _damageValue;
        }
        if (collision.gameObject.CompareTag("PlayerHand") && _gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            _lifePoint -= _damageValue;
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected



    #endregion
}
