using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class PlayNormalization : MonoBehaviour
{
    RectTransform button;

    void Start()
    {
        button = GetComponent<RectTransform>();
        float newDistanceX = 0.019f * ((float)Screen.width / 2f);
        float newDistanceY = 0.5f * ((float)Screen.height / 2f);
        button.anchoredPosition = new Vector3(-newDistanceX, -newDistanceY, 0f);
    }
}