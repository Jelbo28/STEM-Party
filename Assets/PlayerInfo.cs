using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [SerializeField]
    string characterName;
    [SerializeField]
    string extension;
    [SerializeField]
    bool AI;
    [SerializeField]
    int mingamePts;
    [SerializeField]
    int totalPts;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
