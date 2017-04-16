using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {

    [SerializeField]
    private GameObject gameStart;


	// Use this for initialization
	void Start () {
        //gameStart = GameObject.Find("GameStartText");
        GameStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        //gameStart.SetActive(true);
        StartCoroutine(TempActivate(gameStart, 3.5f));
    }

    IEnumerator TempActivate(GameObject toActivate, float waitTime)
    {
        toActivate.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        toActivate.SetActive(false);
    }
}
