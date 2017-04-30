using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    [HideInInspector]
    public bool endGame;
  
    [SerializeField] private List<MonoBehaviour> scripts;
    [SerializeField] private float startDelay;
    [SerializeField] public GameObject[] stuffToDisable;
    [SerializeField] private MonoBehaviour[] thangs;
    private int dataPts = 0;

    private DisplayManager displayManager;
    private PlayerInfo thisPlayer;
    private void Start()
    {
        foreach (PlayerInfo player in FindObjectOfType<ScoreManager>().players)
        {
            if (player.thisUser == true)
            {
                thisPlayer = player;
                break;
            }
        }
        displayManager = FindObjectOfType<DisplayManager>();
        foreach (GameObject stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in stuff.GetComponents(typeof (MonoBehaviour)))
            {
                    scripts.Add(script);
            }
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            foreach (Animator anim in stuff.GetComponents(typeof (Animator)))
            {
                animators.Add(anim);
            }
            foreach (Animator anim in animators)
            {
                anim.enabled = false;
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
        displayManager.EndGameScreen();
    }

    private void BeginGame()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        foreach (Animator anim in animators)
        {
            anim.enabled = true;
        }
        displayManager.BeginGame();
    }


    public void AddPoints(int ammount)
    {
        dataPts += ammount;
        thisPlayer.mingamePts = dataPts;
        displayManager.UpdatePoints(dataPts);
    }

}