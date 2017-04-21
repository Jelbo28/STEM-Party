using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
    [SerializeField]
    string[] killNames;
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
                other.transform.GetChild(0).gameObject.SetActive(true);
                other.transform.parent.GetComponent<TopDown2DMovement>().walkSpeed -= 2.5f;
                other.transform.parent.GetComponent<Rigidbody>().mass += 50;
                other.transform.parent.GetComponent<Rigidbody>().drag = 20;
                //other.transform.parent.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (string target in killNames)
        {
            //Debug.Log(other.gameObject.name);
            if (other.gameObject.name == target)
            {
                other.transform.GetChild(0).gameObject.SetActive(false);
                other.transform.parent.GetComponent<TopDown2DMovement>().walkSpeed += 2.5f;
                other.transform.parent.GetComponent<Rigidbody>().mass -= 50;
                other.transform.parent.GetComponent<Rigidbody>().drag = 0;
                //other.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
