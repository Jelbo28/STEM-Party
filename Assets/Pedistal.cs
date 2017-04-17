using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{
    [SerializeField] private float stopPoint;
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float pitch;
    private bool stop = true;

    void Start ()
    {
	    anim = GetComponent<Animator>();
	    audio = GetComponentInChildren<AudioSource>();
        //clips[0] = audio.clip;
        //pitch = audio.pitch * stopPoint;
    }
	
	void Update ()
	{
	    if (stopPoint <= 0)
	    {
            Stop();
        }
        else
	    {
            stopPoint -= Time.deltaTime;
        }
    }

    void Stop()
    {
        if (stop)
        {
            anim.speed = 0;
            //audio.pitch = pitch;
            audio.Stop();
            audio.PlayOneShot(clip, pitch);
            //Debug.Log("Audio!");
            stop = false;
        }

    }
}
