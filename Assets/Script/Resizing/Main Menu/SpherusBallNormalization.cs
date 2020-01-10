using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class SpherusBallNormalization : MonoBehaviour
{
    RectTransform image;
    int keyWidth = 1149;
    int keyHeight = 591;

    void Start()
    {
        image = GetComponent<RectTransform>();
        float widthMultiplier = (float)Screen.width / (float)keyWidth;
        float heightMultiplier = (float)Screen.height / (float)keyHeight;
        image.transform.localScale = new Vector3(widthMultiplier, heightMultiplier, 0f);
    }
}