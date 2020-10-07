using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIL : MonoBehaviour
{
    public static bool FloorIsLava;
    // Start is called before the first frame update
    public void FilSetter(bool fil) {
        FloorIsLava = fil;
    }
}
