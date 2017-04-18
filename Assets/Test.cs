using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField]
    private Pedistal[] pedistals;

	// Use this for initialization
	void Start () {
        pedistals = GameObject.FindObjectsOfType<Pedistal>();
        //for (int i = 0; i < 4; i++)
        //{
        //    SetPedistal(i + 1, i);
        //}
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
