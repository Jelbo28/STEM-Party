using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbito : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float orbitSpeed;


    void Update()
    {

        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotateSpeed * Time.deltaTime);
        transform.Translate(orbitSpeed * Time.deltaTime, 0, 0);

    }
}
