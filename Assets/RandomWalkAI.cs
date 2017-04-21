using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkAI : MonoBehaviour {
    [SerializeField]
    Vector3 moveBounds;
    [SerializeField]
    bool turn =false;
    [SerializeField]private Vector3 destination;
    private TopDown2DMovement thisController;
	// Use this for initialization
	void Start () {
        thisController = GetComponent<TopDown2DMovement>();
        WalkToPoint();
    }
	

    void WalkToPoint()
    {
        destination = new Vector3(Random.Range(-moveBounds.x, moveBounds.x), transform.position.y/*Random.Range(-moveBounds.y, moveBounds.y)*/, Random.Range(-moveBounds.z, moveBounds.z));
        thisController.target = destination;
        turn = true;
    }
}
