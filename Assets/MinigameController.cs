using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private GameObject[] stuffToDisable;
    [SerializeField] private GameObject GameStartText;
    [SerializeField] private List<MonoBehaviour> scripts;

    [SerializeField] private float startDelay;
    // Use this for initialization
    private void Start()
    {
        Cursor.visible = false;
        foreach (var stuff in stuffToDisable)
        {
            //stuff.GetComponents(typeof(MonoBehaviour));
            foreach (MonoBehaviour script in stuff.GetComponents(typeof (MonoBehaviour)))
            {
                scripts.Add(script);
            }
            foreach (var script in scripts)
            {
                script.enabled = false;
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (startDelay >= 0)
        {
            startDelay -= Time.deltaTime;
        }
        else
        {
            BeginGame();
        }
    }

    private void BeginGame()
    {
        foreach (var script in scripts)
        {
            script.enabled = true;
        }
        GameStartText.SetActive(true);
    }

    public void EndGame(PlayerInfo winner)
    {
    }
}
