using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {
    [SerializeField]
    bool instaQuit = false;
    [SerializeField]
    string sceneTo;
    [SerializeField]
    bool userInput;
    [SerializeField]
    KeyCode inputKey = KeyCode.Space;
    private SceneChanger sceneChanger;
	// Use this for initialization
	void Start () {
        sceneChanger = FindObjectOfType<SceneChanger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(inputKey))
        {
            if (!instaQuit)
            {
                sceneChanger.LoadSceneByName(sceneTo);

            }
            else
            {
                Application.Quit();
            }
        }
    }
}
