using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{
    [SerializeField] private float stopPoint;
    [SerializeField] private string place;
    [SerializeField]
    private int playerState;
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

    void SetPedistal(int level)
    {
        switch (level)
        {
            case 1:
                place = "1st";
                stopPoint = 1.5f;
                break;
            case 2:
                place = "2nd";
                stopPoint = 1;
                break;
            case 3:
                place = "3rd";
                stopPoint = 0;
                break;
            case 4:
                place = "4th";
                stopPoint = 0;
                break;


        }
        GetComponentInChildren<TextMesh>().text = place;

    }
}
