using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    [SerializeField] private float endDelay;
    [SerializeField] private GameObject Fade;
    [SerializeField] private GameObject[] GameText;
    private string origText;
    [SerializeField] private Text PtsText;
    private SceneChanger sceneChanger;

    private void Start()
    {
        origText = PtsText.text;
        PtsText.text = origText + 0;
        sceneChanger = FindObjectOfType<SceneChanger>();
        Fade.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void Update()
    {
    }

    public void BeginGame()
    {
        GameText[0].SetActive(true);
    }

    public void EndGameScreen()
    {
        GameText[1].SetActive(true);
        endDelay -= Time.deltaTime;
        if (!(endDelay <= 3)) return;
        GameText[1].GetComponent<Text>().text = "Ending in... " + Mathf.RoundToInt(endDelay);
        if (!(endDelay <= 1.5f)) return;
        Fade.GetComponent<Animator>().SetTrigger("FadeOut");
        if (!(endDelay <= 1)) return;
        Time.timeScale -= Time.deltaTime;
        if (endDelay <= 0.5f)
        {
            Cursor.visible = true;
            sceneChanger.LoadSceneByName("Minigame Results");
        }
    }

    public void UpdatePoints(float value)
    {
        PtsText.text = origText + value;
    }
}