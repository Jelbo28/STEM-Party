using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PeriodicElement : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float force;
    private Animator anim;
    private ElementChase elementChase;
    private Rigidbody2D rb;
    private Vector3 newDir;
    [SerializeField] private Vector2 timerRange;
    [SerializeField]
    private Vector2 forceRange;

    // Use this for initialization
    void Start ()
	{
	    rb = GetComponent<Rigidbody2D>();
	    elementChase = FindObjectOfType<ElementChase>();
	    anim = GetComponent<Animator>();
	    //timer = Random.Range(timerRange.x, timerRange.y);
	}

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 2)
            {
                transform.Rotate(Vector3.forward * -90 * Time.deltaTime);

            }
        }
        else
        {
            newDir = Random.insideUnitCircle*3;
            rb.AddForce(transform.up*Random.Range(forceRange.x,forceRange.y)*Time.deltaTime);
            timer = Random.Range(timerRange.x, timerRange.y);
        }
    }

    void OnMouseDown()
    {
        elementChase.AddElement(name);
        anim.SetTrigger("Poof");

    }
}
