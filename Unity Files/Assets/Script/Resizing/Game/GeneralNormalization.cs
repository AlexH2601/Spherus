using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Alex Huang

public class GeneralNormalization : MonoBehaviour
{
    RectTransform rectTrans;
    int keyWidth = 1272;
    int keyHeight = 591;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        float widthMultiplier = (float)Screen.width / (float)keyWidth;
        float heightMultiplier = (float)Screen.height / (float)keyHeight;
        rectTrans.transform.localScale = new Vector3(widthMultiplier, heightMultiplier, 1f);
    }
}