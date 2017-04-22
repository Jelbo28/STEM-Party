using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePoint : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponentInParent<TopDown2DMovement>().thisPlayer.mingamePts++;
        Destroy(gameObject);
    }
}
