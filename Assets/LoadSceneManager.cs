using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    private void Start()
    {

    }


    public void LoadScene1()
    {
        SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single); //replace by Test 1, or SampleScene
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Scenes/Test 1", LoadSceneMode.Single); //replace by Test 1, or SampleScene
    }
}
