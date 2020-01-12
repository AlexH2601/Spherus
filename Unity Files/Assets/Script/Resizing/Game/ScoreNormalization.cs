using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class ScoreNormalization : MonoBehaviour
{
    RectTransform text;

    void Start()
    {
        text = GetComponent<RectTransform>();
        float newDistanceX = 0.38f * ((float)Screen.width / 2f);
        float newDistanceY = 0.63f * ((float)Screen.height / 2f);
        text.anchoredPosition = new Vector3(-newDistanceX, newDistanceY, 0f);
    }
}