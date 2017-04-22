using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    //[SerializeField]
    //private GameObject gameStart;

    [SerializeField]
    private GameObject Fade;
    [SerializeField]
    private GameObject[] GameText;
    [SerializeField]
    private float endDelay;

    private SceneChanger sceneChanger;


    // Use this for initialization
    void Start () {
        sceneChanger = FindObjectOfType<SceneChanger>();
        Fade.GetComponent<Animator>().SetTrigger("FadeIn");
        //gameStart = GameObject.Find("GameStartText");
        //GameStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginGame()
    {
        GameText[0].SetActive(true);

    }

    //public void GameStart()
    //{
    //    //gameStart.SetActive(true);
    //    StartCoroutine(TempActivate(gameStart, 3.5f));
    //}

    //IEnumerator TempActivate(GameObject toActivate, float waitTime)
    //{
    //    toActivate.SetActive(true);
    //    yield return new WaitForSeconds(waitTime);
    //    toActivate.SetActive(false);
    //}

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
            // Time.timeScale = 0;
            Cursor.visible = true;
            sceneChanger.LoadSceneByName("Minigame Results");
        }
    }
}
