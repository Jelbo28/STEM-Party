using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CartesianCatastrophie : MonoBehaviour
{
    [SerializeField] private float instanceAmmount = 0;
    [SerializeField]
    private float timerLength = 5f;
    [SerializeField]
    private bool timerOn = false;
    [SerializeField]
    Text timerText;
    [SerializeField]
    private Vector2 coordinates;

    [SerializeField]
    private  float resetTimerLength ;
    [SerializeField]
    Text[] coordinatesText;
    private float timer = 5f;
    private float currInstanceAmmount = 0;
    private Animator[] blocks;
    [SerializeField]private float resetTimer;
    private Animator anim;
    [SerializeField]private bool reset = true;
    [SerializeField]private TopDown2DMovement[] players;
    // Use this for initialization
    void Awake ()
    {
        resetTimer = resetTimerLength;
        players = FindObjectsOfType<TopDown2DMovement>();
        blocks = GameObject.Find("Blocks").GetComponentsInChildren<Animator>();
        timer = timerLength;
        currInstanceAmmount = 0;;
        anim = GetComponent< Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Timer();
        Reset();
	}

    public void GenerateCoordinates()
    {
        currInstanceAmmount++;
        if (currInstanceAmmount > instanceAmmount)
        {
            GameOver();
        }
        else
        {
            coordinates = new Vector2(Random.Range(-99, 99), Random.Range(-99, 99));

            while (coordinates.x == 0 || coordinates.y == 0)
            {
                coordinates = new Vector2(Random.Range(-99, 99), Random.Range(-99, 99));
            }
            coordinatesText[0].text = coordinates.ToString("f0");
        }

    }

    public void SetCoordinates()
    {
        coordinatesText[1].text = coordinates.ToString("f0");
        timerOn = true;
    }

    void Timer()
    {
        if (timerOn)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.Round(timer).ToString("0f");
            }
            else
            {
                if (coordinates.x > 0 && coordinates.y > 0)
                {
                                     blocks[1].SetTrigger("GoUnder");
                    blocks[2].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");

                }
                else if (coordinates.x < 0 && coordinates.y > 0)
                {
                    blocks[0].SetTrigger("GoUnder");
                    blocks[2].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");
                }
                else if (coordinates.x < 0 && coordinates.y < 0)
                {
                    blocks[0].SetTrigger("GoUnder");
                    blocks[1].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");
                }
                else if (coordinates.x > 0 && coordinates.y < 0)

                {
                    blocks[0].SetTrigger("GoUnder");
                    blocks[1].SetTrigger("GoUnder");
                    blocks[2].SetTrigger("GoUnder");
                }
                reset = true;
                timer = timerLength;
                timerOn = false;
            }
        }
    }

    private void GameOver()
    {
        anim.speed = 0;
        transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("Gameover, dude.");
    }

    private void Reset()
    {
        if (!reset) return;
        if (resetTimer >= 0)
        {
            resetTimer -= Time.deltaTime;
        }
        else
        {
            resetTimer = resetTimerLength;
            foreach (TopDown2DMovement player in players)
            {
                if (!player.thisPlayer.AI) continue;
                //Debug.Log("Yooooo");
                player.waitAI = 1f;
                player.go = true;
            }
            GetComponent<Letter>().PlayAnimation();
            reset = false;
        }
    }
}
