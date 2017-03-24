using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    Transform offset;
    [SerializeField]
    GameObject player;

	// Use this for initialization
	void Start () {
        transform.position = /*player.transform.position + */offset.position;
        //transform.rotation = player.transform.rotation + offset.rotation;

    }

    // Update is called once per frame
    void Update () {
        LookAtPlayer();
	}

    void LookAtPlayer()
    {
        Vector3 forward = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
