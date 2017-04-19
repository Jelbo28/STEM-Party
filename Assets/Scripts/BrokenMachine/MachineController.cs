﻿using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    [SerializeField] private bool AIControl;
    [SerializeField] private float AITimer;
    [SerializeField] private Vector2 AITimerRange;
    private MinigameController manager;
    [SerializeField] private List<BrokenPart> parts;
    [SerializeField] private int playerNum;
    [SerializeField] private bool reset;
    [HideInInspector] public PlayerInfo thisPlayer;
    //private int partNum = 0;
    private void Awake()
    {
        manager = FindObjectOfType<MinigameController>();
        //Debug.Log(name + " ," + (playerNum - 1))     ;
        thisPlayer =
            FindObjectOfType<ScoreManager>().players[playerNum - 1];
        //Debug.Log(name + " = " +thisPlayer);
        //thisPlayer = players[playerNum - 1];
        //Debug.Log(name + " = " + thisPlayer);
        for (var i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<BrokenPart>() == true)
                parts.Add(transform.GetChild(i).GetComponent<BrokenPart>());
        }
        AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
    }

    private void Update()
    {
        thisPlayer =
            FindObjectOfType<ScoreManager>().players[playerNum - 1];
        //Debug.Log(name + " = " + thisPlayer);
        if (reset)
        {
            foreach (BrokenPart part in parts)
            {
                ChangePart(part, false);
            }
            reset = false;
        }
        AI();
    }

    private void AI()
    {
        //List<int> parts = new List<int>();
        AITimer -= Time.deltaTime;
        if (!AIControl || !(AITimer <= 0)) return;
        var partNum = Mathf.RoundToInt(Random.Range(0, parts.Count));
        if (parts.Count >= 1)
        {
            parts.Remove(parts[partNum]);
            ChangePart(parts[partNum], true);
            parts[partNum].broken = false;
            parts[partNum].health = parts[partNum].origHealth;
            AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
        }
        //partNum++;
        else
        {
            Debug.Log(name + " = " + parts.Count);
            manager.SetWinner(thisPlayer);
            AIControl = false;
        }
    }

    public void ChangePart(BrokenPart part, bool fix)
    {
        if (part.swapMesh)
        {
            ChangeMesh(fix ? part.toMesh : part.origMesh, part);
        }

        if (part.swapMaterial)
        {
            ChangeMaterial(fix ? part.toMaterial : part.origMaterial, part);
        }

        if (part.swapChildState)
        {
            ToggleChild(part);
        }

        if (part.enableSwapper)
        {
            if (fix)
            {
                EnableSwapper(part, true);
            }

            else
            {
                EnableSwapper(part, false);
                ChangeMaterial(part.origMaterial, part);
            }
        }
        if (fix)
        {
            part.transform.GetChild(0).GetComponent<ObjectSpewer>().go = true;
        }
        if (parts.Count <= 0)
        {
            manager.SetWinner(thisPlayer);
        }
    }

    private static void ChangeMesh(Mesh newMesh, BrokenPart target)
    {
        target.GetComponent<MeshFilter>().sharedMesh = newMesh;
    }

    private static void ChangeMaterial(Material newMaterial, BrokenPart target)
    {
        target.GetComponent<MeshRenderer>().sharedMaterial = newMaterial;
    }

    //private void EnableChild(BrokenPart target, bool enable)
    //{
    //    target.transform.GetChild(0).gameObject.SetActive(enable);
    //}

    private static void ToggleChild(BrokenPart target)
    {
        for (var i = 0; i < target.transform.childCount; i++)
        {
            target.transform.GetChild(i)
                .gameObject.SetActive(!target.transform.GetChild(i).gameObject.activeInHierarchy);
        }
    }

    private static void EnableSwapper(BrokenPart target, bool enable)
    {
        target.GetComponent<MaterialSwapper>().stop = !enable;
        target.GetComponent<MaterialSwapper>().reset = !enable;
    }
}