using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Add : MonoBehaviour
{
    private Text scoreaddText;
    public float points = 0;
    public int pointSet;
    
    void Start()
    {
        scoreaddText = GetComponent<Text>();
        points = 0;
        pointSet = 0;
    }

    void FixedUpdate()
    {
        scoreaddText.text = "+"+points.ToString();
    }
    public void AddPoints()
    {
        pointSet++;
        if (pointSet < 3)
        {
            points = 50;
        }
        else if (pointSet < 5)
        {
            points = 75;
        }
        else if (pointSet < 7)
        {
            points = 125;
        }
        else if (pointSet < 9)
        {
            points = 250;
        }
        else if (pointSet >= 9)
        {
            points = 500;
        }
        Score.scoreAmount += points;
    }
}
