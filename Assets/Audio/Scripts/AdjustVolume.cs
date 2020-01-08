using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    public void ChangeVol(float newValue)
    {
        //defining new Volume, equal to initial volume of AudioListener
        float newVol = AudioListener.volume;
        //Value changed as slider is moved
        newVol = newValue;
        //New volume is sent to the audio listener
        AudioListener.volume = newVol;
    }

}
