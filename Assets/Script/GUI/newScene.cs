﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class newScene : MonoBehaviour
{

    public void changeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
