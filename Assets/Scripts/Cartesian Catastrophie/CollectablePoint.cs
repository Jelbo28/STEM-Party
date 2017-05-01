using UnityEngine;

public class CollectablePoint : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private MinigameController minigameController;

    private void Awake()
    {
        minigameController = FindObjectOfType<MinigameController>();
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        minigameController.AddPoints(1);
        //other.GetComponentInParent<TopDown2DMovement>().thisPlayer.mingamePts++;
        Destroy(gameObject);
    }
}