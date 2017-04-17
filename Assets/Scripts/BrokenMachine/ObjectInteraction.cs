using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float viewDistance;
    [SerializeField] private GameObject indexCard;
    [SerializeField] private Image crosshair;
    [SerializeField] private Color crosshairNormal;
    [SerializeField] private Color crosshairHighlight;
    [SerializeField] private Text fixCount;
    [SerializeField]
    private Text ptsCount;


    private int parts;
    private bool indexUp;

    [SerializeField]
    private int playerNum;
    private PlayerInfo[] players;
    private PlayerInfo thisPlayer;
    private MinigameController manager;

    private void Update()
    {
        players = FindObjectsOfType<PlayerInfo>();
        thisPlayer = players[playerNum + 2];
        manager = FindObjectOfType<MinigameController>();

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
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.GetComponent<BrokenPart>())
                {
                    BrokenPart brokenPart = hit.transform.GetComponent<BrokenPart>();
                    brokenPart.health -= damage;

                    if (brokenPart.health <= 0 &&
                        brokenPart.broken)
                    {
                        hit.transform.parent.GetComponent<MachineController>().ChangePart(brokenPart, true);
                        brokenPart.health =
                            brokenPart.origHealth;
                        brokenPart.broken = false;
                        parts++;
                        fixCount.text = parts + "/" + 4;
                        if (parts >= 4)
                        {
                            thisPlayer.SetWinner();
                            manager.EndGame(thisPlayer);

                        }
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
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
