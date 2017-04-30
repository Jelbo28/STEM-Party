using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private float delay;
    private bool quit;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
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

    private IEnumerator SceneDelay(string scene)
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