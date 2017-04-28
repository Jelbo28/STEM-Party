using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicElement : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float force;
    private Animator anim;
    private ElementChase elementChase;
    private Rigidbody2D rb;
    private float newRot;
    [SerializeField] private Vector2 timerRange;
    [SerializeField]
    private float rotRange;

    [SerializeField]
    private Vector2 forceRange;

    // Use this for initialization
    void Start ()
    {
        timer = Random.Range(timerRange.x, timerRange.y);
	    rb = GetComponent<Rigidbody2D>();
	    elementChase = FindObjectOfType<ElementChase>();
	    anim = GetComponent<Animator>();
        newRot = Random.Range(-rotRange, rotRange);

        //timer = Random.Range(timerRange.x, timerRange.y);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 1)
            {
                transform.Rotate(Vector3.forward * newRot * Time.deltaTime);

            }
        }
        else if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < .5f)
        {
            newRot = Random.Range(-rotRange, rotRange);
            force = Random.Range(forceRange.x, forceRange.y);
            rb.AddForce(transform.up*force*Time.deltaTime);
            timer = Random.Range(timerRange.x, timerRange.y);

        }
        else
        {
            rb.velocity *= Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("eddy");
        elementChase.AddElement(name);
        anim.SetTrigger("Poof");

    }
}
