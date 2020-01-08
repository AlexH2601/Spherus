using UnityEngine;
using UnityEngine.UI;

public class SoundActivation : MonoBehaviour
{
    //References to all the different button objects that will yield a "click noise"
    public Button Play, Options, Quit, Back;

    void Start()
    {
        Play.onClick.AddListener(TaskOnClick);
        Options.onClick.AddListener(TaskOnClick);
        Quit.onClick.AddListener(TaskOnClick);
        Back.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void TaskOnClick()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
