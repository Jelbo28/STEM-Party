using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    [SerializeField]
    private Player[] players;
    [SerializeField]
    private bool newGame;
    private DisplayManager dispManager;
	// Use this for initialization
	void Start () {
        if (newGame)
        {
            BeginGame();
        }
        players = GameObject.Find("Players").GetComponentsInChildren<Player>();
        dispManager = GameObject.FindObjectOfType<DisplayManager>();
	}
	
	public void NewTurn()
    {

    }

    void BeginGame()
    {
        dispManager.BeginGame();
    }
}
