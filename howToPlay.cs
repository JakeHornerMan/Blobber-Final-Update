using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlay : MonoBehaviour
{
    public Animator anim;
    public enum State { fadein, fadeout }
    private IEnumerator coroutine;
    public State mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = State.fadein;
    }

    public void FixedUpdate()
    {
        anim.SetInteger("mode", (int)mode);
    }

    // Update is called once per frame
    public void htpMENU(bool see) {
        if (see == true) {
            mode = State.fadein;
            //anim.SetInteger("mode", (int)mode);
        }
        if (see == false)
        {
            mode = State.fadeout;
            //anim.SetInteger("mode", (int)mode);
        }
    }
}
