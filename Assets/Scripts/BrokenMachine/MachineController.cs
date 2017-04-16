using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour {
    [SerializeField]
    int playerNum;
    [SerializeField]
    List<BrokenPart> parts;
    [SerializeField]
    private bool reset;
    [SerializeField]
    private bool AIControl = false;
    [SerializeField]
    private Vector2 AITimerRange;
    [SerializeField]
    private float AITimer;
    private MinigameController manager;
    private PlayerInfo[] players;
    private PlayerInfo thisPlayer;
	
    void Start()
    {
        players = FindObjectsOfType<PlayerInfo>();
        thisPlayer = players[playerNum - 1];
        manager = FindObjectOfType<MinigameController>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<BrokenPart>() == true)
                parts.Add(transform.GetChild(i).GetComponent<BrokenPart>());
        }
        AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
    }

	void Update () {

        if (reset)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                ChangePart(parts[i], false);
            }
            reset = false;
        }
        AI();
    }

    void AI()
    {
        //List<int> parts = new List<int>();
        AITimer -= Time.deltaTime;
        if (AIControl && AITimer <= 0)
        {
            int partNum = Mathf.RoundToInt(Random.Range(0, parts.Count));
            parts.Remove(parts[partNum]);
            if (parts.Count <= 0)
            {
                manager.EndGame(thisPlayer);
            }
            ChangePart(parts[partNum], true);
            parts[partNum].broken = false;
            parts[partNum].health = parts[partNum].origHealth;
            AITimer = Random.Range(AITimerRange.x, AITimerRange.y);
        }
    }

    public void ChangePart(BrokenPart part, bool fix)
    {

        if (part.swapMesh)
        {
            if (fix)
            {
                ChangeMesh(part.toMesh, part);
            }

            else
            {
                ChangeMesh(part.origMesh, part);
            }
        }

        if (part.swapMaterial)
        {
            if (fix)
            {
                ChangeMaterial(part.toMaterial, part);
            }

            else
            {
                ChangeMaterial(part.origMaterial, part);
            }
        }

        if (part.swapChildState)
        {
            if (fix)
            {
                ToggleChild(part);
            }

            else
            {
                ToggleChild(part);
            }
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
    }


    void ChangeMesh(Mesh newMesh, BrokenPart target)
    {
        target.GetComponent<MeshFilter>().sharedMesh = newMesh;
    }

    void ChangeMaterial(Material newMaterial, BrokenPart target)
    {
        target.GetComponent<MeshRenderer>().sharedMaterial = newMaterial;
    }

    void EnableChild(BrokenPart target, bool enable)
    {
        target.transform.GetChild(0).gameObject.SetActive(enable);
    }

    void ToggleChild(BrokenPart target)
    {
        for (int i = 0; i < target.transform.childCount; i++)
        {
            target.transform.GetChild(i).gameObject.SetActive(!target.transform.GetChild(i).gameObject.activeInHierarchy);
        }
    }

    void EnableSwapper(BrokenPart target, bool enable)
    {
        target.GetComponent<MaterialSwapper>().stop = !enable;
        target.GetComponent<MaterialSwapper>().reset = !enable;
    }
}
