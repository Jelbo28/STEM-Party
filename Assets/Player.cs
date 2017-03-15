using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    Tile[] tiles;
    //[SerializeField]
    //Vector3 offset;
    //private Vector3 tileOffset;
    [SerializeField]
    int rollNum;
    [SerializeField]
    private int num = 0;

    [SerializeField]
    private float minDist;
    [SerializeField]
    public float speed;
    [SerializeField]
    private bool go = false;

    private Transform target;
	// Use this for initialization
	void Start () {
        tiles = GameObject.Find("Points").GetComponentsInChildren<Tile>();
        //tileOffset = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, tiles[num].transform.position/* + tileOffset*/);
        if (Input.GetButtonDown("A Button"))
        {
            rollNum = Mathf.RoundToInt(Random.Range(1, 6));
            go = true;
        }
        if (go)
        {
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
}
