//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollow : MonoBehaviour {
//    [SerializeField]
//    Transform offset;
//    [SerializeField]
//    GameObject player;

//	// Use this for initialization
//	void Start () {
//        transform.position = /*player.transform.position + */offset.position;
//        //transform.rotation = player.transform.rotation + offset.rotation;

//    }

//    // Update is called once per frame
//    void Update () {
//        LookAtPlayer();
//	}

//    void LookAtPlayer()
//    {
//        Vector3 forward = player.transform.position - transform.position;
//        transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
//    }
//}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
     float turnSpeed = 2.0f;
    [SerializeField]
    float panSpeed = 2.0f;
    [SerializeField]
    float zoomSpeed = 2.0f;
    [SerializeField]
    float shiftBoost = 0.0f;
     

    private Vector3 mouseOrigin;   
    private bool isPanning;     
    private bool isRotating;   
    private bool isZooming;

    public Vector3 zoom = Vector3.zero;
    //private Vector3 zoomOut = Vector3.up;

    void Update()
    {
        Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        //transform.Translate(0, 0, Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftBoost = 2.0f;
        }
        else
        {
            shiftBoost = 0.0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    mouseOrigin = Input.mousePosition;
        //    isPanning = true;
        //}

        if (Input.GetMouseButtonDown(2))
        {
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }

        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;

        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * ((turnSpeed + shiftBoost) + shiftBoost));
            transform.RotateAround(transform.position, Vector3.up, pos.x * (turnSpeed + shiftBoost));
        }

        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * (panSpeed + shiftBoost), pos.y * (panSpeed + shiftBoost), 0);
            transform.Translate(move, Space.Self);
        }

        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * (zoomSpeed + shiftBoost) * transform.forward;
            transform.Translate(move, Space.World);
        }
    }

    void ZoomRange()
    {
        zoom = (Vector3.Distance(transform.position, target.position) > 20) ?   Vector3.up : (Vector3.Distance(transform.position, target.position) < 2) ? Vector3.down : Vector3.zero;


    }
}
