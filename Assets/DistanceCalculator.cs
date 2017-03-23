using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour {

    [SerializeField]
    Transform startPoint;
    private float dist;

	// Use this for initialization
	void Start () {
        while(transform.position.y <= 100 || transform.position.y >= 300)
        {
            transform.position = Random.onUnitSphere * 3845;

        }
    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(transform.position, startPoint.position);
        if (dist == 3845)
        {
            Debug.Log("Goochi");
        }
	}
}
