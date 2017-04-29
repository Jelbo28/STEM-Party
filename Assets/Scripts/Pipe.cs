using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private int pipeType = 0;
    // 0 = Curved, 1 = Straight, 2 = Crossing
      public Pipe[] neighbors;
     public bool correctRot = false;
    [SerializeField] private bool interactable = true;
     public bool finalPipe = false;
    [SerializeField] private float currRotation;
    private int scramble;
    [SerializeField] private float[] acceptableRotations = new float[4];
    [SerializeField] private bool scrambleIt = true;
    // Use this for initialization
    private PipesManager manager;
    void Start ()
    {
        manager = GameObject.FindObjectOfType<PipesManager>();
        for (int i = 0; i < acceptableRotations.Length; i++)
        {
            currRotation = transform.rotation.eulerAngles.z;

            acceptableRotations[i] = transform.rotation.eulerAngles.z;
            switch (pipeType)
            {
                case 0:
                    Rotate();
                    Rotate();
                    Rotate();
                    Rotate();
                    break;
                case 1:
                    Rotate();
                    Rotate();
                    break;
                case 2:
                    Rotate();
                    break;

            }

        }
        if (interactable && scrambleIt)
        {
            scramble = Random.Range(1, 4);
            for (int i = 0; i < scramble; i++)
            {
                Rotate();
            }
        }

    }
	
	// Update is called once per frame
	void Update ()
	{
        CheckRotation();

     //   if (Input.GetKeyDown(KeyCode.Space) && interactable)
	    //{
     //       Rotate();
	    //}
	}

    public void Rotate()
    {
        if (interactable)
        {
            transform.Rotate(0, 0, 90, Space.Self);
            currRotation = transform.rotation.eulerAngles.z;

            CheckRotation();
        }

    }

    void CheckRotation()
    {
        foreach (float rotation in acceptableRotations)
        {
            if (currRotation == rotation)
            {
                correctRot = true;
                break;
            }
            else
            {
                correctRot = false;
            }
        }

        
    }

    public void ActivateNeighbors()
    {
        if (!finalPipe)
        {
            foreach (Pipe neighbor in neighbors)
            {

                neighbor.GetComponent<Animator>().SetBool("Break", !neighbor.correctRot);
                neighbor.GetComponent<Animator>().SetTrigger("PipeGo");
            }
        }
        else
        {
            manager.SetLevel();
        }

    }

    public void GameOver()
    {
        Debug.Log("Game Over!! You freaking suck at this!");
    }

    //void OnMouseDown()
    //{
    //    Rotate();
    //}
}
