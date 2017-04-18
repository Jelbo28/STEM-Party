using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{
    [SerializeField] private Transform[] characters;
    [SerializeField] private float stopPoint;
    [SerializeField] private string place;
    [SerializeField]
    private int playerState;
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float pitch;
    private bool stop = true;
    [SerializeField] private TextMesh pedistalText;

    void Start ()
    {
	    anim = GetComponent<Animator>();
	    audio = GetComponentInChildren<AudioSource>();

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
            audio.clip = clip;
            //audio.pitch = pitch;
            audio.Play();
            //Debug.Log("Audio!");
            stop = false;
        }

    }

    void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }

    public void SetPedistal(int level, int character)
    {
        switch (level)
        {
            case 1:
                place = "1st";
                stopPoint = 3f;
                break;
            case 2:
                place = "2nd";
                stopPoint = 2.5f;
                break;
            case 3:
                place = "3rd";
                stopPoint = 2f;
                break;
            case 4:
                place = "4th";
                stopPoint = 1.5f;
                break;


        }
        characters[character].parent = transform.GetChild(0);
        pedistalText.text = place;

    }
}
