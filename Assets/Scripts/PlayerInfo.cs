using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    public string characterName;
    [SerializeField]
    public string extension;
    [SerializeField]
    bool AI;
    [SerializeField]
    public int mingamePts;
    [SerializeField]
    public int totalPts;

    [SerializeField] public bool winner = false;

    public void SetWinner()
    {
        winner = true;
    }
}
