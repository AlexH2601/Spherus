using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private Transform centerBackground;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= centerBackground.position.x + 60f)
            centerBackground.position = new Vector2(transform.position.x + 60f, centerBackground.position.y);
        else if (transform.position.x <= centerBackground.position.x - 60f)
            centerBackground.position = new Vector2(transform.position.x - 60f, centerBackground.position.y);
    }
}
