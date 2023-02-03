using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeManagement : MonoBehaviour
{
    #region Exposed

    [SerializeField] private int _maxLifePoint = 100;
    [SerializeField] private int _lifePoint;
    [SerializeField] private int _damageValue = 10;

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

    // Collision avec l'ennemmi : on décrémente les points de vie courants du joueur
    private void OnCollisionEnter(Collision collision)
    {
        // Teste si le GameObject avec lequel on est entr? en collision porte le tag Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _lifePoint -= _damageValue;
        }
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected



    #endregion
}
