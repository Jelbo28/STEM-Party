using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    [SerializeField]
    float swapSpeed;
    [SerializeField]
    bool random = true;
    [SerializeField]
    private bool reset = false;
    [SerializeField]
    private bool stop = false;
    [SerializeField]
    Material[] facesTextures;
    private Renderer thisRenderer;

    void Start()
    {
        thisRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (!reset)
        {
            StopAllCoroutines();
            StartCoroutine(Rolling());
            reset = true;
        }
    }

    IEnumerator Rolling()
    {
        int i = 0;
        int oldI = 0;
        while (!stop)
        {
            yield return new WaitForSeconds(swapSpeed);
            if (random)
            {
                while (i == oldI)
                {
                    i = Mathf.RoundToInt(Random.Range(0, facesTextures.Length - 1.1f));
                }
                thisRenderer.material = facesTextures[i];
                oldI = i;
            }
            else
            {
                    i = oldI < facesTextures.Length ? oldI : 0;
                thisRenderer.material = facesTextures[i];
                oldI = i + 1;
            }
        }
    }
}
