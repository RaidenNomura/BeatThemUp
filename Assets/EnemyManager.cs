using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //[SerializeField]
    //Score _score;

    lifeManagement _lifeManagement;
    Score _score;


    private void Awake()
    {
        //bool isHurting = GetComponent<lifeManagement>().isHurting;
        GameObject Score = GameObject.Find("/PlayerUI/score"); //should remain !null
        _score = Score.GetComponent<Score>();
    }
    private void Start()
    {
        Debug.Log("Active EnemyManager");
        //GetComponent<lifeManagement>().isHurting = true; //debug
    }
    private void Update()
    {
        Debug.Log("Etat de isHurting is " + GetComponent<lifeManagement>().isHurting);
        _score.AddScore(10);
        if (GetComponent<lifeManagement>().isHurting)
        {
            Debug.Log("Add Score 10");
            _score.AddScore(10);
        }
    }
}
