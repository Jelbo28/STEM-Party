using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private GameObject[] stuffToDisable;
    [SerializeField] private GameObject[] GameText;
    [SerializeField] private GameObject Fade;
    [SerializeField] private List<MonoBehaviour> scripts;

    [SerializeField] private float startDelay;
    [SerializeField]
    private float endDelay;
    [SerializeField] private MonoBehaviour[] thangs;
    private bool endGame = false;
    // Use this for initialization
    private SceneChanger sceneChanger;
    private void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        Fade.GetComponent<Animator>().SetTrigger("FadeIn");

              foreach (GameObject stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
                       foreach (MonoBehaviour script in stuff.GetComponents(typeof(MonoBehaviour)))
            {
                scripts.Add(script);
            }
                        foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (startDelay >= 0)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            BeginGame();
        }
        if (!endGame) return;
        EndGameScreen();
    }

    private void BeginGame()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        GameText[0].SetActive(true);
    }

    public void EndGame()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
            {
                stuffToDisable[i].GetComponent<MachineController>().gameOver = true;

            }
            else
            {
                stuffToDisable[i].GetComponent<ObjectInteraction>().gameOver = true;


            }
        }
        endGame = true;
    }

    void EndGameScreen()
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
