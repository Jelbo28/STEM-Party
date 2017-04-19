using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

    [SerializeField]
    string[] allScenes;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }


    public void LoadSceneByName(string sceneName)
    {

        for (int i = 0; i < allScenes.Length; i++)
        {
            if (allScenes[i] == sceneName)
            {
                SceneManager.LoadScene(i);
            }
        }
    }
}
