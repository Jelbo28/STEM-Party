using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [SerializeField]
    private Pedistal[] pedistals;

	// Use this for initialization
	void Start () {
        pedistals = GameObject.Find("Pedestals").GetComponentsInChildren<Pedistal>();
        for (int i = 0; i < pedistals.Length; i++)
        {
            pedistals[i].SetPedistal(i + 1, i);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
