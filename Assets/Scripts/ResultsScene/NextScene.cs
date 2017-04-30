using UnityEngine;

public class NextScene : MonoBehaviour
{
    [SerializeField] private readonly KeyCode inputKey = KeyCode.Space;
    [SerializeField] public bool instaQuit;
    private SceneChanger sceneChanger;
    [SerializeField] private string sceneTo;
    [SerializeField] private bool userInput;
    // Use this for initialization
    private void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(inputKey) && userInput)
        {
            ChangeScene(sceneTo);
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