using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We need this in order to access the Text component
// since it is part of the UI
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.Processors;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public bool resetScore = false;

    [SerializeField]
    bool ForceTrueIsHurting;
    private int ScoreHit;

    private static int scoreValue;
    private lifeManagement _lifeManagement;
    private bool isHurting;
    private bool EnemyObject;




    private void Awake()
    {
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");
        //bool isHurting = EnemyObject.GetComponent<lifeManagement>().isHurting;
        _lifeManagement = EnemyObject.GetComponent<lifeManagement>();
    }
    void Start()
    {
        // If we have requested the score to be reset for this scene.... (condition)
        if (resetScore)
        {
            // Reset the score to 0! (action)
            scoreValue = 0;
        }
        scoreDisplay.text = scoreValue.ToString();
    }

    private void Update()
    {
        if(ForceTrueIsHurting)
        {
            _lifeManagement.isHurting = true;
        }

        isHurting = _lifeManagement.isHurting;
        if(_lifeManagement.isHurting)
        {
            Debug.Log("Add Value of Score");
            AddScore(ScoreHit);
        }
    }

    // Function to add to the player's score
    // NOT automatically called by Unity, we need to call it ourselves in our code
    public void AddScore(int toAdd)
    {
        scoreValue = scoreValue + toAdd;
        scoreDisplay.text = scoreValue.ToString();
    }
}
