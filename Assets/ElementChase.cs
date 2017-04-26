using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class ElementChase : MonoBehaviour
{
    [System.Serializable]
    public class Element
    {
        public string name;
        public int count;
        public int prevCount;
        public bool remaining = false;
        public GameObject uiDisp;
    }
    [SerializeField]
    private Element[] elements;

    [SerializeField] private int remainingElements;
    [SerializeField] private int playerScore;
	// Use this for initialization
	void Start () {
        remainingElements = 0;
        CheckElements();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddElement("Phosphorus", true);
        }
    }

    void CheckElements()
    {
        foreach (Element element in elements)
        {
            if (element.count != element.prevCount)
            {
                if (element.count > 0 )
                {
                    if (!element.remaining)
                    {
                        element.remaining = true;
                        remainingElements++;
                    }
             
                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = element.count.ToString();
                    element.uiDisp.SetActive(true);
                }
                else
                {
                    element.remaining = false;
                    remainingElements--;
                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = "0";
                    element.uiDisp.SetActive(false);
                }
                element.prevCount = element.count;
            }
        }
    }

    public void AddElement(string elementName, bool setNew = false)
    {
        foreach (Element element in elements)
        {
            if (element.name == elementName)
            {
                if (!setNew)
                {
                    if (element.count > 0)
                    {
                        element.count--;
                    }
                    else
                    {
                        playerScore--;

                    }
                }
                else
                {
                    element.count++;
                }

            }
        }
        CheckElements();
    }
}
