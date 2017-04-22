using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
    [SerializeField]
    string[] killNames;

    private Transform toKill;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        foreach (string target in killNames)
        {
            //Debug.Log(other.gameObject.name);
            if (other.gameObject.name == target)
            {
                toKill = other.transform;
                Destroy(toKill.parent.gameObject, 3f);
                toKill.GetChild(0).gameObject.SetActive(true);
                toKill.parent.GetComponent<TopDown2DMovement>().walkSpeed -= 2.5f;
                toKill.parent.GetComponent<Rigidbody>().mass += 50;
                toKill.parent.GetComponent<Rigidbody>().drag = 20;
                //toKill.parent.gameObject.SetActive(false);
            }
        }
    }

    //void OnTriggerExit(Collider other)
    //{
    //    foreach (string target in killNames)
    //    {
    //        //Debug.Log(other.gameObject.name);
    //        if (other.gameObject.name == target)
    //        {
    //toKill = other.transform;
    //            toKill.GetChild(0).gameObject.SetActive(false);
    //            toKill.parent.GetComponent<TopDown2DMovement>().walkSpeed += 2.5f;
    //            toKill.parent.GetComponent<Rigidbody>().mass -= 50;
    //            toKill.parent.GetComponent<Rigidbody>().drag = 0;
    //            //toKill.parent.gameObject.SetActive(false);
    //        }
    //    }
    //}
}
