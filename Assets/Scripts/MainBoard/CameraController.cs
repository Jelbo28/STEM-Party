using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    Transform target;
    [SerializeField]
    Transform anchor;
    [SerializeField]
    float dampTime;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotateSpeed;
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        float step = moveSpeed * Time.deltaTime;
        cam.transform.position = Vector3.MoveTowards(transform.position, anchor.position, step);
        float turn = rotateSpeed * Time.deltaTime;
        cam.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(target.transform.position - transform.position), turn);
    }
}
