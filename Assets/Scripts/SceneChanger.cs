using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    private float delay;
    private bool quit;
    void Start() {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {

 
    }

    public void LoadSceneByName(string sceneName)
    {

            StartCoroutine(SceneDelay(sceneName));
        
    }

    public void LoadSceneByIndex(int sceneNumber)
    {
 

     
            StartCoroutine(SceneDelay(sceneNumber.ToString()));
      
    }

    public void SetDelay(float delaySet)
    {
        delay = delaySet;
    }

    IEnumerator SceneDelay(string scene)
    {
        yield return new WaitForSeconds(delay);
        if (!quit)
        {
            SceneManager.LoadScene(scene);

        }
        else
        {
            Application.Quit();

        }
    } 


    public void Quit()
    {
        quit = true;
    }
}
