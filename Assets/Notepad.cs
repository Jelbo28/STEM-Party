using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Notepad : MonoBehaviour {
    [SerializeField]
    string[] posBonusMessages;
    [SerializeField]
    string[] negBonusMessages;
    [SerializeField]
    float negChance;
    [SerializeField]
    TextMesh CScoreText;
    [SerializeField]
    TextMesh DScoreText;
    [SerializeField]
    TextMesh BScoreText;
    [SerializeField]
    TextMesh TScoreText;
    private int bonusScore;
    private int totalScore;
    [SerializeField]
    private PlayerInfo[] players;
    private Pedistal[] pedistals;
    // Use this for initialization
    void Start () {
        players = FindObjectOfType<ScoreManager>().players;
        pedistals = transform.GetChild(2).GetComponentsInChildren<Pedistal>();
        for (int i = 0; i < players.Length; i++)
        {
            pedistals[i].SetPedistal(players[i].place);
            if (players[i].thisUser)
            {
                CScoreText.text = "Competition = " + (players[i].mingameWins > 0 ? "+" : "-") + players[i].mingameWins;
                DScoreText.text = "Data Pts. Found = " + (players[i].mingamePts > 0 ? "+" : "-") + players[i].mingamePts;
                int rand = Random.Range(0, 101);
                bonusScore = Random.Range(0, 21);
                if (rand <= negChance)
                {
                    bonusScore = -bonusScore;
                    BScoreText.text = negBonusMessages[Mathf.RoundToInt(Random.Range(0, negBonusMessages.Length))] + " = " + bonusScore;
                }
                else
                {
                    BScoreText.text = posBonusMessages[Mathf.RoundToInt(Random.Range(0, posBonusMessages.Length))] + " = " + bonusScore;
                }
                totalScore = players[i].mingamePts + players[i].mingameWins + players[i].totalPts + bonusScore;
                TScoreText.text = "Total = " + (totalScore > 0 ? "+" : "-") + totalScore;

            }
        }
	}
}
