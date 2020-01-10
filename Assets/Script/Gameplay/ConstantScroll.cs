using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: David Nygren

public class ConstantScroll : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRend;

    void Update()
    {
        // MOVEMENT OF BACKGROUND GRAPHIC
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);
    }
}