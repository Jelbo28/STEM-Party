using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour {
    [SerializeField]
    BrokenPart[] parts;
    [SerializeField]
    private bool reset;
	
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<BrokenPart>() == true)
                parts[i] = transform.GetChild(i).GetComponent<BrokenPart>();
        }
    }

	void Update () {

        if (reset)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                ChangePart(parts[i], false);
            }
            reset = false;
        }

    }

    public void ChangePart(BrokenPart part, bool fix)
    {

        if (part.swapMesh)
        {
            if (fix)
            {
                ChangeMesh(part.toMesh, part);
            }

            else
            {
                ChangeMesh(part.origMesh, part);
            }
        }

        if (part.swapMaterial)
        {
            if (fix)
            {
                ChangeMaterial(part.toMaterial, part);
            }

            else
            {
                ChangeMaterial(part.origMaterial, part);
            }
        }

        if (part.swapChildState)
        {
            if (fix)
            {
                ToggleChild(part);
            }

            else
            {
                ToggleChild(part);
            }
        }

        if (part.enableSwapper)
        {
            if (fix)
            {
                EnableSwapper(part, true);
            }

            else
            {
                EnableSwapper(part, false);
                ChangeMaterial(part.origMaterial, part);
            }
        }

    }


    void ChangeMesh(Mesh newMesh, BrokenPart target)
    {
        target.GetComponent<MeshFilter>().sharedMesh = newMesh;
    }

    void ChangeMaterial(Material newMaterial, BrokenPart target)
    {
        target.GetComponent<MeshRenderer>().sharedMaterial = newMaterial;
    }

    void EnableChild(BrokenPart target, bool enable)
    {
        target.transform.GetChild(0).gameObject.SetActive(enable);
    }

    void ToggleChild(BrokenPart target)
    {
        for (int i = 0; i < target.transform.childCount; i++)
        {
            target.transform.GetChild(i).gameObject.SetActive(!target.transform.GetChild(i).gameObject.activeInHierarchy);
        }
    }

    void EnableSwapper(BrokenPart target, bool enable)
    {
        target.GetComponent<MaterialSwapper>().stop = !enable;
        target.GetComponent<MaterialSwapper>().reset = !enable;
    }
}
