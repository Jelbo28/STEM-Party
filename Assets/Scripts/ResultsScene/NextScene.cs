using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {
    [SerializeField]
    public bool instaQuit = false;
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
            ChangeScene();
        }
    }

    public void ChangeScene(string scene = " ")
    {
        if (!instaQuit)
        {
            if (sceneTo == "")
            {
                sceneChanger.LoadSceneByName(scene);

            }
            else
            {
                sceneChanger.LoadSceneByName(sceneTo);

            }

        }
        else
        {
            Application.Quit();
        }
    }

    public void SetDelay(float delaySet)
    {
        sceneChanger.SetDelay(delaySet);
    }

    public void Quit()
    {
        instaQuit = true;
    }
}
