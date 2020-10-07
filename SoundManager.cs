using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip absorb, absorbJump, spawnDing, shoot, explosion, hurt, glassSmash, scream;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        absorb = Resources.Load<AudioClip>("absorb");
        absorbJump = Resources.Load<AudioClip>("absorbJump");
        spawnDing = Resources.Load<AudioClip>("spawnDing");
        shoot = Resources.Load<AudioClip>("shoot");
        explosion = Resources.Load<AudioClip>("explosion");
        hurt = Resources.Load<AudioClip>("hurt");
        glassSmash = Resources.Load<AudioClip>("glassSmash");
        scream = Resources.Load<AudioClip>("scream");

        audioSrc = GetComponent<AudioSource>();
    }
        
    public static void PlaySound(string sound) {
        switch (sound) {
            case "absorb":
                audioSrc.PlayOneShot(absorb);
                break;
            case "absorbJump":
                audioSrc.PlayOneShot(absorbJump);
                break;
            case "spawnDing":
                audioSrc.PlayOneShot(spawnDing);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;
            case "glassSmash":
                audioSrc.PlayOneShot(glassSmash);
                break;
            case "scream":
                audioSrc.PlayOneShot(scream);
                break;

        }
    }
}
