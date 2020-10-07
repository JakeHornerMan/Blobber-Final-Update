using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleblue : MonoBehaviour
{
    public Animator anim;
    public enum State { idle, run, fadeout, fadein }
    private IEnumerator coroutine;
    public State mode;
    public float speed = 30f;
    public bool willRun;
    public int fade;
    // Start is called before the first frame update
    void Start()
    {
        mode = State.idle;
        willRun = false;
        fade = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetInteger("mode", (int)mode);
        if (willRun == true && fade == 0) {
            //run();
            mode = State.run;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        } else if (willRun == false && fade == 0) {
            mode = State.idle;
        }
        if (fade == 1) {
            mode = State.fadeout;
        }
        else if (fade == 2) {
            mode = State.fadein;
        }
    }

    public void run() {
        mode = State.run;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }
    
}
