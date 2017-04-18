using UnityEngine;

public class ObjectSpewer : MonoBehaviour
{
    [SerializeField] private GameObject toSpew;
    [SerializeField] private Transform[] spawnAreas;
    [SerializeField] private float forceStrength;
    [SerializeField] private float spawnRange;
    [SerializeField] private Vector2 spewAmmountRange;

    public bool go;
    private int randTransform;
    private GameObject tempSpew;
    private Rigidbody tempSpewRB;


    private void Start()
    {
        spawnAreas = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if ( /*Input.GetKeyDown(KeyCode.Space)*/go)
        {
            for (int j = 0; j < spawnAreas.Length; j++)
            {
                int rand = Mathf.RoundToInt(Random.Range(spewAmmountRange.x, spewAmmountRange.y));

                for (int i = 0; i < rand; i++)
                {
                    tempSpew = Instantiate(toSpew, spawnAreas[j].position + (Random.insideUnitSphere*spawnRange),
                        Quaternion.LookRotation(Vector3.forward));
                    tempSpew.transform.SetParent(GameObject.Find("Data Points").transform);
                    tempSpewRB = tempSpew.GetComponent<Rigidbody>();
                    tempSpewRB.velocity = (Vector3.forward*forceStrength);
                }
            }
            go = false;
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
