using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {

    //Public
    //public GameObject area;
    [SerializeField]
    Collider2D spawnColl;
    public GameObject[] spawnObject;
    //public int MinX = 0;
    //public int MaxX = 10;
    //public int MinY = 0;
    //public int MaxY = 10;
    public int objectAmmount;
    private GameObject toCreate;
    //Private


    void Start()
    {

        //Debug.Log("Spawn");
        int objectType = 0;
        for (int i = 0; i < objectAmmount; i++)
        {
            objectType = Mathf.RoundToInt(Random.Range(0, spawnObject.Length)); // Randomly assigns the object being spawned.
            toCreate = Instantiate(spawnObject[objectType], PointInArea(), Quaternion.identity, transform) as GameObject; // Generates the object with our specified instruction.
            toCreate.name = spawnObject[objectType].name;
        }

    }

    public Vector2 PointInArea()
    {
        Bounds bounds = spawnColl.bounds;
        Vector2 center = bounds.center;

        float x = 0;
        float y = 0;
        int attempt = 0;
        do
        {
            x = Random.Range(center.x - bounds.extents.x, center.x + bounds.extents.x);
            y = Random.Range(center.y - bounds.extents.y, center.y + bounds.extents.y);
            attempt++;
        } while (!GetComponent<PolygonCollider2D>().OverlapPoint(new Vector2(x, y)) && attempt <= 100);


        return new Vector2(x, y);
    }
}
