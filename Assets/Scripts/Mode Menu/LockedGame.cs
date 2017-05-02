using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LockedGame : MonoBehaviour
{
    [SerializeField] private GameObject lockedGameButton;
    [SerializeField]
    private int lockTotal = 5;
    private int gameLock = 0;
    private List<int> lockNums = new List<int>();
    private Text buttonName;

	void Start ()
	{
        DontDestroyOnLoad(gameObject);
	    buttonName = lockedGameButton.GetComponentInChildren<Text>();
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
            buttonName.text = "Credits McShooty";
            lockedGameButton.GetComponent<Button>().interactable = true;
        }
    }
}
