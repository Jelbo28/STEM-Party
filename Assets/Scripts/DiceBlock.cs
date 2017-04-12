using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBlock : MonoBehaviour {
    [SerializeField]
    float rollPeriod;
    [SerializeField]
    Material[] facesTextures;
    private Renderer thisRenderer;
    private bool stop = false;
	// Use this for initialization
	void Start () {
        thisRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(Rolling());
        //Debug.Log(thisRenderer.materials[i].name);
    }
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator Rolling()
    {
        int i = 0;
        int oldI = 0;
        while (!stop)
        {
            yield return new WaitForSeconds(rollPeriod);
            while (i == oldI)
            {
                i = Mathf.RoundToInt(Random.Range(0, 6));
            }
            oldI = i;
            thisRenderer.material = facesTextures[i];
        }
    }
}
