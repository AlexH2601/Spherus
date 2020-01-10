using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Alex Huang

public class newDisplay : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }

    public void appear()
    {
        text.enabled = true;
    }
}