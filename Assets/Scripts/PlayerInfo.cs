using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    public string characterName;
    [SerializeField]
    public string extension;
    [SerializeField]
    public bool AI;
    [SerializeField]
    public bool thisUser;
    [SerializeField]
    public int mingameWins;
    [SerializeField]
    public int mingamePts;
    [SerializeField]
    public int totalPts;

    [SerializeField] public int place = 0;

    public void SetPlace(int placeTo)
    {
        place = placeTo;
    }
}
