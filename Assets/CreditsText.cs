using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsText : MonoBehaviour {

    [SerializeField]
    Vector2 pointRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("woowie");
        if (other.gameObject.tag == "Laser")
        {
            //Debug.Log("bobert");
            GetComponentInParent<TextManager>().Score(pointRange);
            other.gameObject.GetComponent<TestObject>().Explode();
            Destroy(this.gameObject);
        }
    }
}
