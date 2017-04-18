using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorKeeper : MonoBehaviour
{

    [SerializeField] private Color colorToKeep;
    private Color thisColor;

    void Start()
    {
        thisColor = GetComponent<MeshRenderer>().sharedMaterials[0].color;
    }

    void Update()
    {
        if (thisColor != colorToKeep)
        {
            GetComponent<Material>().color = colorToKeep;
        }
    }
}
