using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeNormalization : MonoBehaviour
{
    RectTransform button;

    void Start()
    {
        button = GetComponent<RectTransform>();
        float newDistanceX = 0.55f * ((float)Screen.width / 2f);
        float newDistanceY = 0.15f * ((float)Screen.height / 2f);
        button.anchoredPosition = new Vector3(newDistanceX, -newDistanceY, 0f);
    }
}