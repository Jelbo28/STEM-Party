using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    [SerializeField]
    public PlayerInfo[] players;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        players = GetComponentsInChildren<PlayerInfo>();


    }

    // Update is called once per frame
    void Update () {
		
	}
}
