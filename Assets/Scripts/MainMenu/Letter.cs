using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {
    [SerializeField]
    [Range(0,1)]
    float startingOffset;


    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.Play("LetterFloaty", -1, startingOffset);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
