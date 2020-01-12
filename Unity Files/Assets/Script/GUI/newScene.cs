using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: David Nygren

public class newScene : MonoBehaviour
{
    public void changeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}