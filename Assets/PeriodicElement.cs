using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicElement : MonoBehaviour
{
    private Animator anim;
    private ElementChase elementChase;
	// Use this for initialization
	void Start ()
	{
	    elementChase = FindObjectOfType<ElementChase>();
	    anim = GetComponent<Animator>();
	}

    void OnMouseDown()
    {
        elementChase.AddElement(name);
        anim.SetTrigger("Poof");

    }
}
