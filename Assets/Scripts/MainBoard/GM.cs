using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    [SerializeField]
    private Player[] players;
    [SerializeField]
    private bool newGame;
    private DisplayManager dispManager;
    private int playerTurn;
    private int[] playerRollNum;
	// Use this for initialization
    private CameraFollow cameraSetup;
    private PlayerBanner bannerControl;
	void Start ()
	{
	    bannerControl = FindObjectOfType<PlayerBanner>();

	    cameraSetup = FindObjectOfType<CameraFollow>();
        players = GameObject.Find("Ships").GetComponentsInChildren<Player>();
        dispManager = GameObject.FindObjectOfType<DisplayManager>();
        if (newGame)
        {
            BeginGame();
        }
    }
	
	public void NewTurn(int currPlayer)
	{
	    Debug.Log(players[currPlayer].GetComponent<Player>().thisPlayer.characterName);
        bannerControl.SetPlayer(players[currPlayer].GetComponent<Player>().thisPlayer.characterName);
        cameraSetup.SetTarget(players[currPlayer].transform.GetChild(2));
       // Debug.Log(players[currPlayer].transform.GetChild(2).name);
    }

    void BeginGame()
    {
        //dispManager.BeginGame();
        NewTurn(Random.Range(0,players.Length));
    }
}
