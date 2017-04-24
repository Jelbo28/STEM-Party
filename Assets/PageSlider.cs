using UnityEngine;

public class PageSlider : MonoBehaviour
{
    [SerializeField] private bool left;
    [SerializeField] private float[] origX;
    [SerializeField] private Transform[] pages;
    [SerializeField] private float speed;
    [SerializeField] private bool transition;
    // Use this for initialization
    private void Start()
    {
        //pages = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (transition)
        {
            if (left)
            {
                for (int i = 0; i < pages.Length; i++)
                {
                    if (pages[i].transform.position.x > origX[i] - 1600)
                    {
                        pages[i].transform.position += Vector3.left*speed*Time.deltaTime;
                    }
                    else
                    {
                        transition = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < pages.Length; i++)
                {
                    if (pages[i].transform.position.x < origX[i] + 1600)
                    {
                        pages[i].transform.position += Vector3.right*speed*Time.deltaTime;
                    }
                    else
                    {
                        transition = false;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < pages.Length; i++)
            {
                origX[i] = pages[i].transform.position.x;
            }
        }
    }
}