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

    private int parts;
    private bool indexUp;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                hit.transform.GetComponent<BrokenPart>().health -= damage;

                if (hit.transform.GetComponent<BrokenPart>().health <= 0 &&
                    hit.transform.GetComponent<BrokenPart>().broken)
                {
                    hit.transform.parent.GetComponent<MachineController>()
                        .ChangePart(hit.transform.GetComponent<BrokenPart>(), true);
                    hit.transform.GetComponent<BrokenPart>().health =
                        hit.transform.GetComponent<BrokenPart>().origHealth;
                    hit.transform.GetComponent<BrokenPart>().broken = false;
                    parts++;
                    fixCount.text = parts + "/" + 4;
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
