using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] creditComponents;

	// Use this for initialization
	void Start () {
        StartCoroutine(TextLoop());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator TextLoop()
    {
        int i = 1;
        while (1 == 1)
        {
            yield return new WaitForSeconds(5);

           creditComponents[i].SetActive(true);
            i++;
            if (i > creditComponents.Length)
            {
                StopAllCoroutines();
            }

            Debug.Log("Bobbbbb");
        }

    }
}
