using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    [SerializeField] private Color crosshairHighlight;
    [SerializeField] private Color crosshairNormal;
    [SerializeField] private float damage;
    [SerializeField] private Text fixCount;
    [SerializeField] private GameObject indexCard;
    private bool indexUp;
    private BrokenMachine manager;
    private int parts;
    [SerializeField] private Text ptsCount;
    [SerializeField] private PlayerInfo thisPlayer;
    [SerializeField] private float viewDistance;
    public bool gameOver = false;
    private Animator hammerAnim;

    private void Awake()
    {
        manager = FindObjectOfType<BrokenMachine>();
        thisPlayer = GetComponentInParent<MachineController>().currPlayer;
        hammerAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, viewDistance))
        {
            Debug.DrawLine(ray.origin, hit.point);

            if (hit.transform.tag == "Interactable")
            {
                indexCard.GetComponent<Animator>().SetTrigger("SlideUp");
                indexUp = true;
                indexCard.GetComponentInChildren<Text>().text = hit.transform.name;
                crosshair.color = crosshairHighlight;


                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.GetComponent<BrokenPart>())
                    {
                        BrokenPart brokenPart = hit.transform.GetComponent<BrokenPart>();
                        brokenPart.health -= damage;
                        hammerAnim.SetTrigger("Ham");

                        if (brokenPart.health <= 0 &&
                            brokenPart.broken)
                        {
                            hit.transform.parent.GetComponent<MachineController>().ChangePart(brokenPart, true);
                            brokenPart.health =
                                brokenPart.origHealth;
                            brokenPart.broken = false;
                            parts++;
                            fixCount.text = parts + "/" + 4;
                            if (parts == 4)
                            {
                                thisPlayer.SetPlace(1);
                                thisPlayer.mingameWins += 10;
                                manager.EndGame();
                            }
                        }
                    }
                }
                if (!Input.GetMouseButtonDown(1)) return;
                if (hit.transform.name == "Data Point")
                {
                    thisPlayer.mingamePts++;
                    ptsCount.text = "Data Pts: " + thisPlayer.mingamePts;
                    hit.transform.gameObject.SetActive(false);
                }
            }

        }
        else
        {
            if (indexUp)
            {
                indexCard.GetComponent<Animator>().SetTrigger("SlideDown");
                indexUp = false;
            }
            //indexCard.GetComponentInChildren<Text>().text = " ";
            crosshair.color = crosshairNormal;
        }
    }
}