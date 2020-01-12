using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class ObstacleSelection : MonoBehaviour
{
    private GameObject[] locations;
    private string[] data;

    void Start()
    {
        locations = GameObject.FindGameObjectsWithTag("Obstacle");
        dataImporter();
    }

    void Update()
    {
        
    }

    void dataImporter()
    {
        StreamReader reader = new StreamReader("Assets/Data/Obstacles");
        data = reader.ReadToEnd().Split(';');
        dataTransfer();
    }

    void dataTransfer()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i].Trim();
        }
    }
    
    void obstacleSelection()
    {
        foreach (GameObject obstacle in locations)
        {
            int rand = Mathf.RoundToInt(Random.Range(0f, (float)data.Length));
            
        }
    }
}