using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countup : MonoBehaviour
{
    public static float time;
    public Text Timer;
    public static bool End;
    // Start is called before the first frame update
    void Start()
    {
        //Player_Move.FloorIsLava = true;
        Timer.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (End == false)
        {
            time += Time.deltaTime;
        }
        else {
            return;
        }
        Timer.text = Mathf.Round(time).ToString();
    }
    public void Over(bool end) {
        End = end;
    }
}
