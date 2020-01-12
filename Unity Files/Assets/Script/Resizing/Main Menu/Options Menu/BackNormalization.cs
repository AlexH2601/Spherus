using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class BackNormalization : MonoBehaviour
{
    RectTransform button;

    void Start()
    {
        button = GetComponent<RectTransform>();
        float newDistanceY = 0.41f * ((float)Screen.height / 2f);
        button.anchoredPosition = new Vector3(0f, -newDistanceY, 0f);
    }
}