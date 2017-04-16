using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour {

    [SerializeField]
    GameObject[] stuffToDisable;
    [SerializeField]
    GameObject GameStartText;
    [SerializeField]
    List<MonoBehaviour> scripts;

    [SerializeField]
    float startDelay;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        foreach (GameObject stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in stuff.GetComponents(typeof(MonoBehaviour)))
            {
                scripts.Add(script);
            }
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }

            DontDestroyOnLoad(gameObject);
  
    }
	
	// Update is called once per frame
	void Update () {
        if (startDelay >= 0)
        {
            startDelay -= Time.deltaTime;
                }
        else {
             BeginGame();
        }

    }

    void BeginGame()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        GameStartText.SetActive(true);
    }

    public void EndGame(PlayerInfo winner)
    {

    }
}
