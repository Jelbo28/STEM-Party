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
	void Start () {

	    cameraSetup = FindObjectOfType<CameraFollow>();
	    playerTurn = Random.Range(0, players.Length);
        players = GameObject.Find("Ships").GetComponentsInChildren<Player>();
        dispManager = GameObject.FindObjectOfType<DisplayManager>();
        if (newGame)
        {
            BeginGame();
        }
    }
	
	public void NewTurn(int currPlayer)
    {
        cameraSetup.SetTarget(players[currPlayer].transform.GetChild(2));
       // Debug.Log(players[currPlayer].transform.GetChild(2).name);
    }

    void BeginGame()
    {
        //dispManager.BeginGame();
        NewTurn(playerTurn);
    }
}
