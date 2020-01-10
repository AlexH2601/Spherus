using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Domagala

public class AdjustVolume : MonoBehaviour
{
    public void ChangeVol(float newValue)
    {
        // DEFINING NEW VOLUME (EQUAL TO INITIAL VOLUME OF AUDIOLISTENER
        float newVol = AudioListener.volume;
        // VOLUME VALUE CHANGED AS SLIDE IS MOVED
        newVol = newValue;
        // NEW VOLUME SENT TO AUDIO LISTENER
        AudioListener.volume = newVol;
    }
}