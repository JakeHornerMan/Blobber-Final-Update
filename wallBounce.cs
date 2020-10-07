using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour
{
   
    GameObject player;
    private bool touchWall;
    
    void Start() {
        player = GameObject.Find("Player");
        touchWall = false;
    }

   
    
    void FixedUpdate()
    {
        if (touchWall == true) {
            player.GetComponent<Player_Move>().Slide = true;
        }
        else if (touchWall == false) {
            player.GetComponent<Player_Move>().Slide = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D wall)
    {

        if (wall.gameObject.tag == "Wall")
        {
            touchWall = true;
            player.GetComponent<Player_Move>().wallBounce();
        }
    }
    public void OnCollisionExit2D(Collision2D wall)
    {
        touchWall = false;
    }
}
