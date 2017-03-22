using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChanger : MonoBehaviour
{
    private GM gameManager;
    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GM>().GetComponent<GM>();
        Debug.Log(gameManager.name);
    }

    public void ChangeTurn()
    {
        gameManager.NewTurn();
    }
}