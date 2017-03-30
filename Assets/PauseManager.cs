using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    [SerializeField]
    AudioMixerSnapshot paused;
    [SerializeField]
    AudioMixerSnapshot unpaused;

    private Canvas canvas;


	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
	}

    void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else
        {
            unpaused.TransitionTo(.01f);
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
