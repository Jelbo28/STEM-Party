using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{
    [SerializeField] private Transform[] characters;
    [SerializeField] private float stopPoint;
    [SerializeField] public string place;
    private Animator anim;
    private AudioSource audio;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float pitch;
    private bool stop = true;
    [SerializeField] private TextMesh pedistalText;

    //private Transform playerAnchor;
    [SerializeField] private Animator charAnim;

    void Start ()
    {
        //characters = GameObject.Find("Characters").GetComponentsInChildren<Transform>();
        //playerAnchor = transform.GetChild(0);
        //charAnim = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
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

    public void SetPedistal(int level)
    {
        switch (level)
        {
            case 1:
                place = "1st";
                stopPoint = 3f;
                charAnim.SetInteger("State", 1);
                break;
            case 2:
                place = "2nd";
                stopPoint = 2.5f;
                charAnim.SetInteger("State", 2);
                break;
            case 3:
                place = "3rd";
                stopPoint = 2f;
                charAnim.SetInteger("State", 2);
                break;
            case 4:
                place = "4th";
                stopPoint = 1.5f;
                charAnim.SetInteger("State", 3);
                break;


        }
        //int pedistalNum = 0;
        //switch (characterName)
        //{
        //    case "Red":
        //        pedistalNum = 0;
        //        break;
        //    case "Blue":
        //        pedistalNum = 1;
        //        break;
        //    case "Green":
        //        pedistalNum = 2;
        //        break;
        //    case "Yellow":
        //        pedistalNum = 3;
        //        break;

        //}
        //characters[pedistalNum].position = playerAnchor.position;

        //characters[pedistalNum].parent = playerAnchor;
        pedistalText.text = place;

    }
}
