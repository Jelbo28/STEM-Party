using UnityEngine;

public class TopDown2DMovement : MonoBehaviour
{
    // Normal Movements Variables
    //AI Variables
    [SerializeField] private bool AI;
    private AudioSource audio;
    //[SerializeField] private float AIWaitPeriod;
    [SerializeField] private Letter[] blocks;
    public int correctTile = 0;
    private float curSpeed;
    [SerializeField] private Vector3 destination;
    [HideInInspector] public bool go = false;
    [SerializeField] public float inteligence;
    private Vector3 lastDest;
    //Minigame Variables
    private CartesianCatastrophie minigameCC;
    [SerializeField] private bool move = true;
    [SerializeField] private Vector2 moveBounds;
    private PlayerInfo[] players;
    private Rigidbody rBody;
    [SerializeField] public PlayerInfo thisPlayer;
    [SerializeField] public float waitAI;
    [SerializeField] public float walkSpeed;

    private void Start()
    {
        //waitAI = AIWaitPeriod;

        minigameCC = FindObjectOfType<CartesianCatastrophie>();
        blocks = GameObject.Find("Blocks").GetComponentsInChildren<Letter>();

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

    private void Update()
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
            while (lastDest == destination)
            {
                Debug.Log("WTF");
                if (inteligence > 5)
                {
                    Debug.Log(blocks[minigameCC.correct].transform.name);
                    destination = blocks[minigameCC.correct].transform.GetChild(0).position +
                                      new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                          Random.Range(-moveBounds.y, moveBounds.y));
                }
                else
                {
                    destination = blocks[Random.Range(0, blocks.Length)].transform.position +
                                      new Vector3(Random.Range(-moveBounds.x, moveBounds.x), 0,
                                          Random.Range(-moveBounds.y, moveBounds.y));
                    inteligence = Random.Range(inteligence, inteligence + 7);
                }
                destination.y = transform.position.y;
                //    Random.Range(-moveBounds.y, moveBounds.y));
            }
            Debug.Log(name + " = " + destination);

            if (Mathf.Abs(Vector3.Distance(transform.position, destination)) <= .1f)
            {
                Debug.Log("jerry");
                rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
                go = false;
                lastDest = destination;
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(destination - transform.position);
                //rBody.AddForce((destination - transform.position).normalized * 300);
                rBody.AddForce(transform.forward * 50);
                //Vector3 changeVelocity = (destination - transform.position)*walkSpeed;
                //rBody.velocity = new Vector3(changeVelocity.x, rBody.velocity.y, changeVelocity.z);
                //Debug.Log(name +" = "+rBody.velocity);
                go = false;
            }
        }
    }

    public void Damage()
    {
        audio.Play();
    }
}