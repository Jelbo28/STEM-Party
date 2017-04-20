using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {


    void Start() {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

 
    }

    public void LoadSceneByName(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
