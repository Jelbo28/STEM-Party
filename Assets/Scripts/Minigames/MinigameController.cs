using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;
    private int dataPts;
    private DisplayManager displayManager;
    [HideInInspector] public bool endGame;
    [SerializeField] private List<MonoBehaviour> scripts;
    [SerializeField] private float startDelay;
    [SerializeField] public GameObject[] stuffToDisable;
    [SerializeField] private MonoBehaviour[] thangs;
    public PlayerInfo thisPlayer;

    private void Start()
    {
        foreach (var player in FindObjectOfType<ScoreManager>().players)
        {
            if (player.thisUser)
            {
                thisPlayer = player;
                break;
            }
        }
        displayManager = FindObjectOfType<DisplayManager>();
        foreach (var stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in stuff.GetComponents(typeof (MonoBehaviour)))
            {
                scripts.Add(script);
            }
            foreach (var script in scripts)
            {
                script.enabled = false;
            }
            foreach (Animator anim in stuff.GetComponents(typeof (Animator)))
            {
                animators.Add(anim);
            }
            foreach (var anim in animators)
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
        foreach (var script in scripts)
        {
            script.enabled = true;
        }
        foreach (var anim in animators)
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