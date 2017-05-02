using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquationsManager : MonoBehaviour {
    [System.Serializable]
    public class QuestionPanel
    {
        public int correctOption;
        public GameObject toEnable;
    }

    [SerializeField] private QuestionPanel[] questions;
    [SerializeField] private int questionNumber = 0;
    private MinigameController minigameController;
    [SerializeField] private Text correctDisplay;
	// Use this for initialization
	void Start ()
	{
	    minigameController = FindObjectOfType<MinigameController>();
		NextQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respond(int answer)
    {
        Debug.Log(answer);
        if (answer == questions[questionNumber].correctOption)
        {
            minigameController.AddPoints(3);
            correctDisplay.text = "Correct!";
            //correctDisplay.color = answer == questions[questionNumber - 1].correctOption ? Color.green : Color.red;
            correctDisplay.GetComponent<Animator>().SetBool("Correct", true);
            StartCoroutine(NextQuestion());
        }
        else
        {
            minigameController.AddPoints(-1);
            correctDisplay.GetComponent<Animator>().SetBool("Correct", false);
            correctDisplay.text = "Incorrect!";
        }
        correctDisplay.GetComponent<Animator>().SetTrigger("Go");

    }

     IEnumerator NextQuestion()
     {

            yield return new WaitForSeconds(1);
            questions[questionNumber].toEnable.SetActive(false);
        questionNumber++;
        if (questionNumber < questions.Length)
        {
            questions[questionNumber].toEnable.SetActive(true);
        }
         else
         {
             minigameController.displayManager.endGame = true;
         }



    }
}
