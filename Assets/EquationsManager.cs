using System.Collections;
using System.Collections.Generic;
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
	// Use this for initialization
	void Start () {
		NextQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respond(int answer)
    {
        if (answer == questions[questionNumber-1].correctOption)
        {
            Debug.Log("Correct!");
            NextQuestion();
        }
        else
        {
            Debug.Log("Wrong!");

        }
    }

    void NextQuestion()
    {
        if (questionNumber > 0)
            questions[questionNumber - 1].toEnable.SetActive(false);
        questions[questionNumber].toEnable.SetActive(true);
        questionNumber++;

    }
}
