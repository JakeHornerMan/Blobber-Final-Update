﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Vector3 ShotPos;
    Vector3 targetPos;
    GameObject player;

    public Animator anim;
    private enum State { fireball, explode }
    private State action;
    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //FloorIsLava = Player_Move.FloorIsLava;
        ShotPos = player.transform.position;
        ShotPos.y -= 50;
        action = State.fireball;
        //Move(ShotPos, 15f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(ShotPos, 10f);
        coroutine = WaitAndExplode(4.5f);
        StartCoroutine(coroutine);
        exploSound();
    }
    private void Move(Vector3 target, float movementSpeed)
    {
        //Move
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
    IEnumerator WaitAndExplode(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        action = State.explode;
        anim.SetInteger("state", (int)action);
        coroutine = WaitAndDestroy(.5f);
        StartCoroutine(coroutine);

    }
    IEnumerator WaitAndDestroy(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (FIL.FloorIsLava == false)
            {
                FindObjectOfType<Health>().Damage();
            }
            else if (FIL.FloorIsLava == true) {
                FindObjectOfType<Health>().DamageFIL();
            }
            coroutine = WaitAndExplode(0f);
            StartCoroutine(coroutine);
        }
    }
    void exploSound() {
        if (action == State.explode) {
            //SoundManager.PlaySound("explosion");
        }
    }
}
