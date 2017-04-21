using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown2DMovement : MonoBehaviour {
    // Normal Movements Variables
    [SerializeField] private bool auto;
    [SerializeField]
    public float walkSpeed;
    private float curSpeed;
    [SerializeField]
    private float maxSpeed;
    private Rigidbody rBody;
    [HideInInspector]
    public Vector3 target;
    [SerializeField] private PlayerInfo thisPlayer;
    private PlayerInfo[] players;
    
    [SerializeField] private bool go =true;
    void Start()
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

    void FixedUpdate()
    {

        curSpeed = walkSpeed;
        maxSpeed = curSpeed;
        if (!auto)
        {
            rBody.velocity = new Vector3(Input.GetAxis("Horizontal") * curSpeed,
rBody.velocity.y,
Input.GetAxis("Vertical") * curSpeed);
            if (Mathf.Abs(rBody.velocity.x) > 0 || Mathf.Abs(rBody.velocity.z) > 0)
            {
                transform.rotation = Quaternion.LookRotation(rBody.velocity);
            }
            else
            {
                rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
            }
        }
        else if(go && auto)
        {
            
            if (Mathf.Abs(Vector3.Distance(transform.position, target)) <= 1)
            {
                return;
            }
            rBody.velocity = (target - transform.position).normalized * walkSpeed;
            transform.rotation = Quaternion.LookRotation(rBody.velocity);

        }
        else
        {
          rBody.velocity = rBody.velocity = new Vector3(0, rBody.velocity.y, 0);
            go = false;
        }


    }

    public void Damage()
    {
        
    }
}
