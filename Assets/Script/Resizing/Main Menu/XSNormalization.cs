using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class XSNormalization : MonoBehaviour
{
    RectTransform image;
    int keyWidth = 1149;
    int keyHeight = 591;

    void Start()
    {
        image = GetComponent<RectTransform>();
        float widthMultiplier = (float)Screen.width / (float)keyWidth;
        float heightMultiplier = (float)Screen.height / (float)keyHeight;
        image.transform.localScale = new Vector3(0.75f * widthMultiplier, 0.75f * heightMultiplier, 0f);
        float newDistanceX = 0.005f * ((float)Screen.width / 2f);
        float newDistanceY = 0.72f * ((float)Screen.height / 2f);
        image.anchoredPosition = new Vector3(-newDistanceX, -newDistanceY, 0f);
    }
}