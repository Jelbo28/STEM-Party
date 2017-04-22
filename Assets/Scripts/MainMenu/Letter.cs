using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {
    [SerializeField]
    float startingOffset;

    [SerializeField] private string animationName;
    [SerializeField]
    private bool playOnStart = true;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	    if (playOnStart)
	    {
            anim.Play(animationName, -1, startingOffset);

        }
    }
	
	// Update is called once per frame
	public void PlayAnimation ( ) {
        anim.Play(animationName);

    }
}
