using UnityEngine;
using UnityEngine.UI;

public class CartesianCatastrophie : MonoBehaviour
{
    [SerializeField] private float instanceAmmount = 3;
    [SerializeField] private readonly float timerLength = 5f;
    private Animator anim;
    private Animator[] blocks;
    [SerializeField] public Vector2 coordinates;
    [SerializeField] private Text[] coordinatesText;
    private float currInstanceAmmount;
    [SerializeField] private TopDown2DMovement[] players;
    [SerializeField] private bool reset = true;
    [SerializeField] private float resetTimer;
    [SerializeField] private float resetTimerLength;
    private float timer = 5f;
    [SerializeField] private bool timerOn;
    [SerializeField] private Text timerText;
    [HideInInspector]
    public PlayerInfo[] playerInfo;

    public int correct = 0;

    private MinigameController minigameController;
    // Use this for initialization
    private void Awake()
    {
        // resetTimer = resetTimerLength;
        minigameController = FindObjectOfType<MinigameController>();
        players = FindObjectsOfType<TopDown2DMovement>();

        blocks = GameObject.Find("Blocks").GetComponentsInChildren<Animator>();
        timer = timerLength;
        currInstanceAmmount = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
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
            if (coordinates.x > 0 && coordinates.y > 0)
            {
                correct = 0;
            }
            else if (coordinates.x < 0 && coordinates.y > 0)
            {
                correct = 1;
            }
            else if (coordinates.x < 0 && coordinates.y < 0)
            {
                correct = 2;
            }
            else if (coordinates.x > 0 && coordinates.y < 0)

            {
                correct = 3;
            }
        }
    }

    public void SetCoordinates()
    {
        coordinatesText[1].text = coordinates.ToString("f0");
        foreach (TopDown2DMovement player in players)
        {
                //player.correctTile = correct;
            player.go = true;
        }
        timerOn = true;
    }

    private void Timer()
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
                    blocks[0].GetComponent<ObjectSpewer>().go = true;
                    blocks[1].SetTrigger("GoUnder");
                    blocks[2].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");
                }
                else if (coordinates.x < 0 && coordinates.y > 0)
                {
                    blocks[1].GetComponent<ObjectSpewer>().go = true;
                    blocks[0].SetTrigger("GoUnder");
                    blocks[2].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");
                }
                else if (coordinates.x < 0 && coordinates.y < 0)
                {
                    blocks[2].GetComponent<ObjectSpewer>().go = true;

                    blocks[0].SetTrigger("GoUnder");
                    blocks[1].SetTrigger("GoUnder");
                    blocks[3].SetTrigger("GoUnder");
                }
                else if (coordinates.x > 0 && coordinates.y < 0)

                {
                    blocks[3].GetComponent<ObjectSpewer>().go = true;

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
        //transform.GetChild(1).gameObject.SetActive(true);
        minigameController.endGame = true;
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
            players = FindObjectsOfType<TopDown2DMovement>();
            if (players.Length > 0)
            {
                foreach (var player in players)
                {
                    if (!player.thisPlayer.AI) continue;
                    //Debug.Log("Yooooo");
                    player.waitAI = 1f;
                    player.go = true;
                }
                GetComponent<Letter>().PlayAnimation();
            }
            else
            {
                reset = false;
                GameOver();
            }
        }
    }
}