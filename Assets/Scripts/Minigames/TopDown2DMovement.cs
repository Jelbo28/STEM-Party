using UnityEngine;

public class TopDown2DMovement : MonoBehaviour
{
    //[SerializeField] private float AIWaitPeriod;
    [SerializeField] private Letter[] blocks;
    private float curSpeed;
    [HideInInspector] public bool go;
    // Normal Movements Variables
    //AI Variables
    [SerializeField]
    private bool AI;
    [SerializeField]
    private bool move = true;
    [SerializeField]
    public float waitAI;
    [SerializeField]
    private float inteligence;
    [SerializeField]
    private Vector2 moveBounds;
    [SerializeField]
    private Vector3 destination;
    private Vector3 lastDest;

    //Minigame Specification Variables
    [SerializeField] private string minigameName;
    private CartesianCatastrophie minigameCC;
    private AudioSource audio;

    private PlayerInfo[] players;
    private Rigidbody rBody;
    [SerializeField] public PlayerInfo thisPlayer;
    [SerializeField] public float walkSpeed;

    private void Start()
    {
        //waitAI = AIWaitPeriod;
        switch (minigameName.Trim().ToLower())
        {
            case "cartesiancatastrophie":
                minigameCC = FindObjectOfType<CartesianCatastrophie>();
                blocks = GameObject.Find("Blocks").GetComponentsInChildren<Letter>();
                break;
        }
        rBody = GetComponent<Rigidbody>();
        players = FindObjectOfType<ScoreManager>().transform.GetComponentsInChildren<PlayerInfo>();
        foreach (PlayerInfo player in players)
        {
            if (player.characterName == name)
            {
                thisPlayer = player;
            }
        }

            AI = thisPlayer.AI;
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        curSpeed = walkSpeed;
        if (!AI)
        {
            rBody.velocity = new Vector3(Input.GetAxis("Horizontal")*curSpeed,
                rBody.velocity.y,
                Input.GetAxis("Vertical")*curSpeed);
            if (Mathf.Abs(rBody.velocity.x) > 0 || Mathf.Abs(rBody.velocity.z) > 0)
            {
                transform.rotation = Quaternion.LookRotation(rBody.velocity);
            }
            else
            {
                rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
            }
        }
        else

        {
            WalkToArea();
        }
    }

    public void WalkToArea(Vector3? newDest = null)
    {
        if (!go) return;
        if (waitAI > 0)
        {
            waitAI -= Time.deltaTime;
        }
        else
        {
            if (minigameCC != null)
            {
                while (lastDest == destination)
                {
                    inteligence = Random.Range(inteligence, inteligence + 7);
                    if (inteligence > 5)
                    {
                        int correct = 0;
                        if (minigameCC.coordinates.x > 0 && minigameCC.coordinates.y > 0)
                        {
                            correct = 0;
                        }
                        else if (minigameCC.coordinates.x < 0 && minigameCC.coordinates.y > 0)
                        {
                            correct = 1;
                        }
                        else if (minigameCC.coordinates.x < 0 && minigameCC.coordinates.y < 0)
                        {
                            correct = 2;
                        }
                        else if (minigameCC.coordinates.x > 0 && minigameCC.coordinates.y < 0)

                        {
                            correct = 3;
                        }
                        destination = blocks[correct].transform.GetChild(0).position +
                                      new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                          Random.Range(-moveBounds.y, moveBounds.y));
                    }
                    else
                    {
                        destination = blocks[Random.Range(0, blocks.Length)].transform.position +
                                      new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                          Random.Range(-moveBounds.y, moveBounds.y));
                    }
                    destination.y = transform.position.y;
                    //    Random.Range(-moveBounds.y, moveBounds.y));
                }
            }
            else
            {
                while (lastDest == destination)
                {
                    destination = (Vector3) (newDest != null ? newDest+
                                                               new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                                                   Random.Range(-moveBounds.y, moveBounds.y)) : new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                                                       Random.Range(-moveBounds.y, moveBounds.y)));
                }


            }
        //waitAI = AIWaitPeriod;


            if (Mathf.Abs(Vector3.Distance(transform.position, destination)) <= .1f ||
                Mathf.Abs(rBody.velocity.y) > .2f)
            {
                rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
                go = false;
                lastDest = destination;
            }
            else
            {
                Vector3 changeVelocity = (destination - transform.position).normalized*walkSpeed;
                rBody.velocity = new Vector3(changeVelocity.x, rBody.velocity.y, changeVelocity.z);
                transform.rotation = Quaternion.LookRotation(rBody.velocity);
            }
        }
    }

    public void Damage()
    {
        audio.Play();
    }
}