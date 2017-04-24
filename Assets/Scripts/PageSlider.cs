using UnityEngine;

public class PageSlider : MonoBehaviour
{
    //   [SerializeField]
    //   private float speed;
    //   [SerializeField]
    //   private bool transition;
    //   [SerializeField] private bool left;
    //   [SerializeField] private float xMove;
    //   [SerializeField]
    //private  float[] toX = new float[5];
    //   [SerializeField]
    //   private  float[] fromX = new float[5];

    //   [SerializeField] private Transform[] pages;

    //   // Use this for initialization
    //   private void Start()
    //   {
    //       SetPosition();


    //   }

    //   // Update is called once per frame
    //   private void Update()
    //   {
    //       if (transition)
    //       {
    //           for (int i = 0; i < pages.Length; i++)
    //           {
    //               if (left && pages[i].GetComponent<RectTransform>().localPosition.x >= fromX[i] - toX[i])
    //               {
    //                   pages[i].GetComponent<RectTransform>().Translate(-speed * Time.deltaTime, 0, 0);
    //               }
    //               else if (!left && pages[i].GetComponent<RectTransform>().localPosition.x <= fromX[i] + toX[i])
    //               {
    //                   pages[i].GetComponent<RectTransform>().Translate(speed * Time.deltaTime, 0, 0);
    //               }
    //               else
    //               {


    //                   SetPosition();
    //               }
    //           }

    //       }

    //   }

    //   void SetPosition()
    //   {
    //       for (int i = 0; i < pages.Length; i++)
    //       {
    //           Vector3 bob = new Vector3(fromX[i] - toX[i], pages[i].GetComponent<RectTransform>().localPosition.y, pages[i].GetComponent<RectTransform>().localPosition.z);
    //           pages[i].GetComponent<RectTransform>().position = bob;
    //           toX[i] = xMove;
    //           fromX[i] = pages[i].GetComponent<RectTransform>().localPosition.x;
    //       }
    //       transition = false;
    //   }

    private RectTransform thisRect;
    [SerializeField]
    Vector3 newPos = new Vector3(-1600, 0, 0);
    private Vector3 speed = Vector3.zero;
    [SerializeField]
    private float smoothTime = 0.5f;

    [SerializeField] private GameObject[] buttons;
    private int pageNum;
    private bool go;
    void Start()
    {
        thisRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (go)
        {
            if (Vector3.Distance(thisRect.localPosition, newPos) > 1f)
            {
                thisRect.localPosition = Vector3.SmoothDamp(thisRect.localPosition, newPos, ref speed, smoothTime);
            }
            else
            {
          
                    buttons[1].SetActive(!(pageNum >= 4));
                buttons[0].SetActive(!(pageNum <= 0));

                go = false;
            }
        }
    }

    public void Left()
    {
        if (!go)
        {

            newPos = new Vector3(thisRect.localPosition.x + 1600, 0, 0);
           // Debug.Log(newPos);
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