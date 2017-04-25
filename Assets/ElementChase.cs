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
        public GameObject uiDisp;
    }
    [SerializeField]
    private Element[] elements;

    [SerializeField] private int remainingElements;
    [SerializeField] private int playerScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        CheckElements();
	    }
	}

    void CheckElements()
    {
        remainingElements = 0;
        foreach (Element element in elements)
        {
            if (element.count != element.prevCount)
            {
                if (element.count > 0)
                {
                    remainingElements++;
                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = element.count.ToString();
                    element.uiDisp.SetActive(true);
                }
                else
                {
                    element.uiDisp.transform.GetChild(0).GetComponent<Text>().text = "0";
                    element.uiDisp.SetActive(false);
                }
            }
        }
    }

    public void AddElement(string elementName)
    {
        foreach (Element element in elements)
        {
            if (element.name == elementName)
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
        }
        CheckElements();
    }
}
