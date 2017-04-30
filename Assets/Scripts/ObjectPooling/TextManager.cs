using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] creditComponents;
    [SerializeField]
    Text scoreText;


    [SerializeField]
    float duration;

    int pointScore;

    int pointTotal;
    private MinigameController minigameController;
	// Use this for initialization
	void Start ()
	{
	    minigameController = FindObjectOfType<MinigameController>();
        StartCoroutine(TextLoop());
        scoreText.text = "Data Pts: " + pointTotal;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Data Pts: " + pointTotal;
    }

    public void Score(Vector2 valueRange)
    {
       pointScore += Mathf.RoundToInt(Random.Range(valueRange.x, valueRange.y));
        StartCoroutine(CountTo(pointScore));
    }

    IEnumerator TextLoop()
    {
        int i = 1;
        while (i < creditComponents.Length)
        {
            yield return new WaitForSeconds(5);

           creditComponents[i].SetActive(true);
            i++;

            //Debug.Log("Bobbbbb");
        }
        minigameController.endGame = true;

    }

    IEnumerator CountTo(int target)
    {
        int start = pointTotal;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            pointTotal = (int)Mathf.Lerp(start, target, progress);
            //Debug.Log(pointTotal);
            yield return null;
        }
        pointTotal = target;
        minigameController.thisPlayer.mingamePts = pointTotal;
    }
}
