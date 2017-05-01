using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private readonly bool playOnStart = true;
    private Animator anim;
    [SerializeField] private string animationName;
    [SerializeField] private float startingOffset;
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        if (playOnStart)
        {
            anim.Play(animationName, -1, startingOffset);
        }
    }

    // Update is called once per frame
    public void PlayAnimation()
    {
        anim.Play(animationName);
    }

    public void PlayAudio()
    {
        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("No AudioSouce component attached!");
        }
    }
}