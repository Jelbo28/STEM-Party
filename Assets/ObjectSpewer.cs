using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpewer : MonoBehaviour {
    [SerializeField]
    GameObject toSpew;
    [SerializeField]
    float forceStrength;
    [SerializeField]
    float spawnRange;
    [SerializeField]
    private Vector2 spewAmmountRange;

    private int randTransform;
    private GameObject tempSpew;
    private Rigidbody tempSpewRB;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int rand = Mathf.RoundToInt(Random.Range(spewAmmountRange.x, spewAmmountRange.y));

            for (int i = 0; i < rand; i++)
            {

                tempSpew = Instantiate(toSpew, transform.position + (Random.insideUnitSphere * spawnRange), Quaternion.LookRotation(Vector3.forward)) as GameObject;
                tempSpewRB = tempSpew.GetComponent<Rigidbody>();
                tempSpewRB.velocity = (Vector3.forward * forceStrength);
            }
        }
    }


    //Vector3 GetPointOnUnitSphereCap(Quaternion targetDirection, float angle)
    //{
    // float angleInRad = Random.Range(0.0f, angle) * Mathf.Deg2Rad;
    //Vector2 PointOnCircle = (Random.insideUnitCircle.normalized * 5f) * Mathf.Sin(angleInRad);
    //Vector3 V = new Vector3(PointOnCircle.x, PointOnCircle.y, Mathf.Cos(angleInRad));
    // return targetDirection* V;
    //}
}
