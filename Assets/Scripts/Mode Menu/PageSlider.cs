using UnityEngine;

public class PageSlider : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private GameObject[] buttons;
    private bool go;
    [SerializeField] private Vector3 newPos = new Vector3(-1600, 0, 0);
    private int pageNum;
    private Vector3 speed = Vector3.zero;
    private RectTransform thisRect;
    [SerializeField] private int pagesLength = 4;

    private void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (go)
        {
            if (Vector3.Distance(thisRect.localPosition, newPos) > 1f)
            {
                thisRect.localPosition = Vector3.SmoothDamp(thisRect.localPosition, newPos, ref speed, smoothTime);
            }
            else
            {
                if (buttons.Length > 0)
                {
                    buttons[0].SetActive(pageNum > 0);
                    buttons[1].SetActive(pageNum < pagesLength && pageNum != 0);
                    buttons[2].SetActive(pageNum == 0);
                }


                go = false;
            }
        }
    }

    public void Left()
    {
        if (!go)
        {
            newPos = new Vector3(thisRect.localPosition.x + 1600, 0, 0);
            pageNum--;
            go = true;
        }
    }

    public void Right()
    {
        if (!go)
        {
            pageNum++;
            newPos = new Vector3(thisRect.localPosition.x - 1600, 0, 0);
            go = true;
        }
    }
}