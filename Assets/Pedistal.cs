using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{

    [SerializeField] private float stopPoint;
    private Animator anim;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (stopPoint <= 0)
	    {
	        anim.speed = 0;
	    }
	    else
	    {
            stopPoint -= Time.deltaTime;

        }
    }
}
