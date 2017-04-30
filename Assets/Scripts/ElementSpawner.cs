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
    public int[] objectAmmount;
    private GameObject toCreate;
    //Private
    //private GameObject instantObject;

    private PoolManager poolManager;
    void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        //Debug.Log("Spawn");
        for (int i = 0; i < spawnObject.Length; i++)
        {
            PoolManager.instance.CreatePool(spawnObject[i], objectAmmount[i]);
            for (int j = 0; j < objectAmmount[i]; j++)
            {
                poolManager.ReuseObject(spawnObject[i], PointInArea(),Quaternion.identity, spawnObject[i].name);
                //spawnObject[i].transform.position = PointInArea();
                //spawnObject[i].SetActive(true);
            }
 
            //spawnObject[i].name = spawnObject[i].name;
            //spawnObject[i.transform.SetParent(GameObject.Find("ElementChase").transform.GetChild(0));
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
        } while (!GetComponent<CircleCollider2D>().OverlapPoint(new Vector2(x, y)) && attempt <= 100);


        return new Vector2(x, y);
    }

    public void Respawn(int elementNum)
    {
        poolManager.ReuseObject(spawnObject[elementNum], PointInArea(), Quaternion.identity, spawnObject[elementNum].name);
    }
}
