using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnchor : MonoBehaviour {
    [SerializeField]
    Transform objectToAnchor;

	void Update ()
	{
	    objectToAnchor.position = transform.position;
	}
}
