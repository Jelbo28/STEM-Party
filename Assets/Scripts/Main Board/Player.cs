using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private readonly bool turn = false;
    private Animator anim;
    private ParticleSystem exhaust;
    [SerializeField] private bool go;
    [SerializeField] private float minDist;
    [SerializeField] private int num = 1;
    [SerializeField] private int playerNum;
    [SerializeField] private int rollNum;
    [SerializeField] public float speed;
    private Transform target;
    [SerializeField] public PlayerInfo thisPlayer;
    [SerializeField] private Tile[] tiles;

    private void Start()
    {
        thisPlayer = FindObjectOfType<ScoreManager>().transform.GetChild(playerNum).GetComponent<PlayerInfo>();
        tiles = GameObject.Find("Points").GetComponentsInChildren<Tile>();
        exhaust = GetComponentInChildren<ParticleSystem>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        TakeTurn();
        var dist = Vector3.Distance(gameObject.transform.position, tiles[num].transform.position);

        if (go && rollNum > 0)
        {
            exhaust.Play();
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                if (num + 1 == tiles.Length)
                {
                    num = 0;
                }
                else
                {
                    num++;
                    rollNum--;
                    //if (rollNum == 1)
                    //{
                    //    tileOffset = offset;

                    //}
                    //else
                    //{
                    //    tileOffset = Vector3.zero;
                    //}
                    if (rollNum <= 0)
                    {
                        gameObject.transform.LookAt(tiles[num].transform.position /* + tileOffset*/);
                        exhaust.Stop();
                        go = false;
                    }
                }
            }
        }
    }

    private void Move()
    {
        gameObject.transform.LookAt(tiles[num].transform.position /* + tileOffset*/);
        gameObject.transform.position += gameObject.transform.forward*speed*Time.deltaTime;
    }

    private void TakeTurn()
    {
        if (turn)
        {
            if (Input.GetButtonDown("A Button") || Input.GetKeyDown(KeyCode.Space) && !go)
            {
                anim.SetTrigger("Jump");
                //rollNum = Mathf.RoundToInt(Random.Range(1, 6));
                //go = true;
            }
        }
    }
}