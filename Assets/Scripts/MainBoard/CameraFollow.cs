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
    float rotateSpeed;
    [SerializeField]
    float panSpeed = 2.0f;
    [SerializeField]
    float zoomSpeed = 2.0f;
    [SerializeField]
    float zoomSpeedA = 2.0f;
    [SerializeField]
    float shiftBoost = 0.0f;
    [SerializeField]
    Vector2 zoomRange;

    [SerializeField] private bool auto;
    [SerializeField] private Vector2 autoPanSpeed;
    private Vector3 startPos;

    private Vector3 mouseOrigin;
    [SerializeField]
    private bool isPanning;
    [SerializeField]
    private bool isRotating;   
    [SerializeField] private bool isZooming;
    [SerializeField] private float panRange;
   private Vector3 move;
    [SerializeField] private bool keyboardMode;

    void Update()
    {
        startPos = transform.position;
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotateSpeed * Time.deltaTime);
        //transform.Translate(0, 0, Time.deltaTime);
        shiftBoost = Input.GetKey(KeyCode.LeftShift) ? 1.2f : 0.0f;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseOrigin = Input.mousePosition;
        //    isRotating = true;
        //}

        if (!auto)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseOrigin = Input.mousePosition;
                isZooming = true;
            }
            if (Input.GetMouseButtonDown(1))
            {
                mouseOrigin = Input.mousePosition;
                //Debug.Log(Input.mousePosition.x);
                isPanning = true;
            }



            //if (!Input.GetMouseButton(0)) isRotating = false;
            if (!Input.GetMouseButton(0)) isZooming = false;
            if (!Input.GetMouseButton(1) && !keyboardMode) isPanning = false;

            if (isRotating)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                //transform.RotateAround(transform.position, transform.right, -pos.y * ((turnSpeed + shiftBoost) + shiftBoost));
                transform.RotateAround(transform.position, Vector3.up, pos.x*(turnSpeed + shiftBoost));
            }

            if (isPanning)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                //Vector3 move = new Vector3 (0, autoPanSpeed,0)  ;
                //Debug.Log(Vector3.Distance(transform.position, startPos));
                if (!keyboardMode)
                {
                     move = new Vector3(pos.x * (panSpeed + shiftBoost), pos.y * (panSpeed + shiftBoost), 0);

                }
                else
                {
                     move = new Vector3(Input.GetAxis("Horizontal") * (panSpeed + shiftBoost) *Time.deltaTime, Input.GetAxis("Vertical") * (panSpeed + shiftBoost) * Time.deltaTime);
                    //move = new Vector3(Mathf.Clamp(move.x, panRange.x, panRange.y), Mathf.Clamp(move.y, panRange.x, panRange.y), 0);

                   // Debug.Log((move));
                }

                //Debug.Log(move.x);
                transform.Translate(move, Space.Self);
                if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) > panRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), (50 + shiftBoost) * Time.deltaTime);
                }
                //GetComponent<Rigidbody2D>().velocity = (move*30*Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, move, panSpeed* Time.deltaTime);
            }

            if (isZooming)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = pos.y*(zoomSpeed + shiftBoost)*transform.forward;
                transform.Translate(move, Space.World);
                ZoomRange();

            }
        }
        else
        {
            
                if (isPanning)
                {
                    //Vector2 move = autoPanSpeed;

                    transform.Translate(autoPanSpeed, Space.Self);
                }
            
        }
    }

    void ZoomRange()
    {
        Vector3 zoom = (Vector3.Distance(transform.position, target.position) > zoomRange.y) ?   Vector3.up * (Vector3.Distance(transform.position, target.position)) : (Vector3.Distance(transform.position, target.position) < zoomRange.x) ? Vector3.down : Vector3.zero;
        transform.Translate((zoom.y/10) * (zoomSpeedA + shiftBoost) * transform.forward, Space.World);
    }

    public void SetTarget(Transform toSet)
    {
        target = toSet;
    }
}


