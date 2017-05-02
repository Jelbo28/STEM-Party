using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private Text totalScore;
    private PlayerInfo[] allPlayers;
    private PlayerInfo thisPlayer;
    private string oldTotalScore;

	void Start ()
	{
	    totalScore = GetComponent<Text>();
	    oldTotalScore = totalScore.text;
	    allPlayers = FindObjectOfType<ScoreManager>().GetComponentsInChildren<PlayerInfo>();
	    foreach (PlayerInfo player in allPlayers)
	    {
	        if (player.thisUser)
	            thisPlayer = player;
	    }
        totalScore.text = oldTotalScore + thisPlayer.totalPts;
    }

}
