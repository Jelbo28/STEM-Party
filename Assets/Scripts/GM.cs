using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    [SerializeField]
    private Player[] players;
    [SerializeField]

	// Use this for initialization
	void Start () {
        players = GameObject.FindObjectsOfType<Player>();
	}
	
	public void NewTurn()
    {

    }
}
