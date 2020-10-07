using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBackground : MonoBehaviour
{
    public Animator anim;
    public enum State { blob, crack }
    public State mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = State.blob;
        anim.SetInteger("mode", (int)mode);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetInteger("mode", (int)mode);
    }

    public void crack() {
        mode = State.crack;
        anim.SetInteger("mode", (int)mode);
    }
}
