using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    Tile[] tiles;
    [SerializeField]
    bool turn = false;
    //[SerializeField]
    //Vector3 offset;
    //private Vector3 tileOffset;
    [SerializeField]
    int rollNum;
    [SerializeField]
    private int num = 1;

    [SerializeField]
    private float minDist;
    [SerializeField]
    public float speed;
    [SerializeField]
    private bool go = false;

    private Transform target;
    private Animator anim;
    private ParticleSystem exhaust;
	// Use this for initialization
	void Start () {
        tiles = GameObject.Find("Points").GetComponentsInChildren<Tile>();
        exhaust = GetComponentInChildren<ParticleSystem>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        //tileOffset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        TakeTurn();
        //if (num == 0) num++;
        float dist = Vector3.Distance(gameObject.transform.position, tiles[num].transform.position/* + tileOffset*/);

        if (go && rollNum > 0)
        {
            exhaust.Play();
            if(dist > minDist)
            {
                Move();
            }
            else
            {

                    if(num + 1 == tiles.Length)
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
                            gameObject.transform.LookAt(tiles[num].transform.position/* + tileOffset*/);
                        exhaust.Stop();
                            go = false;
                        }
                    }
            }
        }
	}

    void Move()
    {
        gameObject.transform.LookAt(tiles[num].transform.position/* + tileOffset*/);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    void TakeTurn()
    {
        if (turn == true)
        {
            if (Input.GetButtonDown("A Button") || Input.GetKeyDown(KeyCode.Space) && !go)
            {
                // transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
                anim.SetTrigger("Jump");
                //rollNum = Mathf.RoundToInt(Random.Range(1, 6));
                //go = true;
            }
        }
    }
}
