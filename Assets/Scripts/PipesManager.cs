﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour {
    [System.Serializable]
    public class PipeLevel
    {
        public GameObject levelObject;
        public Animator catalystPipe;
        public int levelTimer;
    }
    [SerializeField] private PipeLevel[] levels;
    [SerializeField] private int currLevel = 0;
    [SerializeField] private float levelTimer = 0;
    private RadialProgressMeter progressMeter;
    private DisplayManager displayManager;
    // Use this for initialization
    void Start ()
    {
        displayManager = FindObjectOfType<DisplayManager>();
        progressMeter = FindObjectOfType<RadialProgressMeter>();
        StartCoroutine(BeginGame());
    }

    // Update is called once per frame
    void Update ()
	{
        if (currLevel > 0)
        {
            if (levelTimer > 0)
                levelTimer -= Time.deltaTime;
            else
            {
                Time.timeScale = 1;
                levels[currLevel - 1].catalystPipe.SetTrigger("PipeGo");
            }
        }

    }

    public void SetLevel()
    {
        if (currLevel <= levels.Length)
        {
            if (currLevel != 0)
                levels[currLevel - 1].levelObject.SetActive(false);
            progressMeter.Activate(levels[currLevel].levelTimer);
            levelTimer = levels[currLevel].levelTimer;
            levels[currLevel].levelObject.SetActive(true);
            currLevel++;
        }
        else
        {
            Debug.Log("Game Over");
        }

    }

    IEnumerator BeginGame()
    {
        displayManager.BeginGame();
        yield return new WaitForSeconds(3f);
        SetLevel();
    }
}
