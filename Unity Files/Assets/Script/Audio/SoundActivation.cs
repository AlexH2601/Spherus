using UnityEngine;
using UnityEngine.UI;

// Author: Alex Domagala

public class SoundActivation : MonoBehaviour
{
    public Button Play, Options, Quit, Back; // References to all buttons that produce a "click noise"

    void Start()
    {
        Play.onClick.AddListener(TaskOnClick);
        Options.onClick.AddListener(TaskOnClick);
        Quit.onClick.AddListener(TaskOnClick);
        Back.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}