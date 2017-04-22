using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenMachine : MonoBehaviour {

    private MinigameController minigameController;

    private MachineController[] machines;
    void Start()
    {
        machines = GetComponentsInChildren<MachineController>();
        minigameController = FindObjectOfType<MinigameController>();
    }
    public void EndGame()
    {
        for (int i = 0; i < machines.Length; i++)
        {
            if (machines[i].transform.GetChild(0).name == "Player")
            {
                machines[i].transform.GetChild(0).GetComponent<ObjectInteraction>().gameOver = true;

            }
            else
            {
                machines[i].gameOver = true;

            }
        }
        minigameController.endGame = true;
    }
}
