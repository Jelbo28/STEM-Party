using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown2DMovement : MonoBehaviour
{
    // Normal Movements Variables
    [SerializeField] private float AIWaitPeriod;
    [SerializeField] private bool AI;
    [SerializeField] public float walkSpeed;
    private float curSpeed;
    [SerializeField] private float maxSpeed;
    private Rigidbody rBody;

    [SerializeField] public PlayerInfo thisPlayer;
    private PlayerInfo[] players;

    [SerializeField] private bool move = true;
    [SerializeField] public float waitAI;
    [HideInInspector] public bool go;
    

    [SerializeField] private Vector2
        moveBounds;

    [SerializeField] private Vector3 destination;
    private Vector3 lastDest;
    [SerializeField]
    private Transform[] blocks;

    private void Start()
    {

        rBody = GetComponent<Rigidbody>();
        players = FindObjectOfType<ScoreManager>().transform.GetComponentsInChildren<PlayerInfo>();
        foreach (PlayerInfo player in players)
        {
            if (player.characterName == name)
            {
                thisPlayer = player;
            }
        }
    }

    private void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;
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
            WalkToPoint();
        }
    }

    private void WalkToPoint()
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

                destination = blocks[Random.Range(0, blocks.Length)].position +new Vector3 (Random.Range(-moveBounds.x, moveBounds.x),0, Random.Range(-moveBounds.y, moveBounds.y));
                destination.y = transform.position.y;
                //    Random.Range(-moveBounds.y, moveBounds.y));
            }
            //waitAI = AIWaitPeriod;


            if (Mathf.Abs(Vector3.Distance(transform.position, destination)) <= .1f ||
                Mathf.Abs(rBody.velocity.y) > .5f)
            {
                rBody.velocity = rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
                go = false;
                lastDest = destination;
            }
            else
            {
                rBody.velocity = (destination - transform.position).normalized*walkSpeed;
                transform.rotation = Quaternion.LookRotation(rBody.velocity);
            }
        }
    }

    public void Damage()
    {
    }
}