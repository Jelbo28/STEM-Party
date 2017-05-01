using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LockedGame : MonoBehaviour {
    [SerializeField]
    private int lockTotal = 5;
    private int gameLock = 0;
    private List<int> lockNums = new List<int>();
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Unlock(int lockNum)
    {
        if (!lockNums.Contains(lockNum))
        {
            gameLock++;
            lockNums.Add(lockNum);
        }
        if (lockNums.Count >= lockTotal)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
