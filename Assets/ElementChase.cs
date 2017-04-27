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
    [System.Serializable]
    public class Level
    {
        public string molName;
        public string[] elementsUsed;
        public int[] howMany;
        public int molMoveType;
    }
    [SerializeField]
    private Element[] elements;
    [SerializeField]
    private Level[] levels;

    [SerializeField] private int remainingElements;
    [SerializeField]
    private Text scoreText;
    [SerializeField] private int playerScore;
  private Transform MoleculeModel;
    private int currLevel = 0;
	// Use this for initialization
	void Start () {
        MoleculeModel = GameObject.Find("3D Molecule").transform;
        //remainingElements = 0;
        //CheckElements();
        BeginLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddElement("Phosphorus", 3, true);
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
                    StartCoroutine(ChangeLevel());
                }
                element.prevCount = element.count;
            }
        }
    }

    public void AddElement(string elementName, int howMany = 1, bool setNew = false)
    {
        foreach (Element element in elements)
        {
            if (element.name == elementName)
            {
                if (!setNew)
                {
                    if (element.remaining)
                    {
                        element.count--;
                        playerScore++;
                        scoreText.text = "Socre: " + playerScore;
                    }
                    else
                    {
                        playerScore--;
                        scoreText.text = "Socre: " + playerScore;
                        break;

                    }

                }
                else
                {
                    element.count += howMany;
                }

            }
        }
        CheckElements();
    }

    public void BeginLevel()
    {
        MoleculeModel.GetChild(1).GetComponent<Text>().text = levels[currLevel].molName;
        MoleculeModel.GetChild(1).GetComponent<Animator>().SetTrigger("SetName");
        if (currLevel > 0)
        {
            MoleculeModel.GetChild(0).GetComponent<Animator>().SetTrigger("Enter");
            MoleculeModel.GetChild(0).GetChild(currLevel - 1).gameObject.SetActive(false);
        }

        MoleculeModel.GetChild(0).GetChild(currLevel).gameObject.SetActive(true);
        MoleculeModel.GetChild(0).GetComponent<Animator>().SetInteger("MoveType", levels[currLevel].molMoveType);
        for (int i = 0; i < levels[currLevel].elementsUsed.Length; i++)
        {
            AddElement(levels[currLevel].elementsUsed[i], levels[currLevel].howMany[i], true);
        }
        currLevel++;
    }

    IEnumerator ChangeLevel()
    {
        if (remainingElements <= 0)
        {
            MoleculeModel.GetChild(0).GetComponent<Animator>().SetTrigger("Exit");
            yield return new WaitForSeconds(2f);
            BeginLevel();
        }
    }
}
