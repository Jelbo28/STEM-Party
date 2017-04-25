using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private string[] killNames;
    private Transform toKill;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string target in killNames)
        {
            //Debug.Log(other.gameObject.name);
            if (other.gameObject.name == target)
            {
                toKill = other.transform;
                toKill.parent.GetComponent<AudioSource>().Play();
                Destroy(toKill.parent.gameObject, 3f);
                toKill.GetChild(0).gameObject.SetActive(true);
                toKill.parent.GetComponent<TopDown2DMovement>().walkSpeed -= 2.5f;
                toKill.parent.GetComponent<Rigidbody>().mass += 50;
                toKill.parent.GetComponent<Rigidbody>().drag = 20;
                //toKill.parent.gameObject.SetActive(false);
            }
        }
    }
}