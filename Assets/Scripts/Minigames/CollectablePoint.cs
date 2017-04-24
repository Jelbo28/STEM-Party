using UnityEngine;

public class CollectablePoint : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponentInParent<TopDown2DMovement>().thisPlayer.mingamePts++;
        Destroy(gameObject);
    }
}