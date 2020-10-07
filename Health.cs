
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    public bool Damagable = true;
    private IEnumerator coroutine;
    GameObject player;
    public bool lastChance;
    public bool viewable;
    

    void Start(){
        player = GameObject.Find("Player");
        lastChance = false;
        viewable = true;
    }

    void Update() {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage() {

        if (Damagable == true) {
            health = health - 1;
            callInvunrable(3f);
            GetComponent<Player_Move>().takingDamage();
        }
        if (health == 0)    
        {
            if (lastChance == false && viewable == true)
            {
                FindObjectOfType<GameManager>().Died();
                viewable = false;
            }
            else if (lastChance == true) {
                
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }

    public void DamageFIL()
    {
        if (Damagable == true)
        {
            health = health - 1;
            callInvunrable(1f);
            GetComponent<Player_Move>().takingDamage();
        }
        if (health == 0)
        {
            if (lastChance == false && viewable == true)
            {
                FindObjectOfType<GameManager>().Died();
                viewable = false;
            }
            else if (lastChance == true)
            {
                FindObjectOfType<GameManager>().GameOverFil();
            }
        }
    }

    IEnumerator InVunrable(float _waitTime)
    {
        Damagable = false;
        yield return new WaitForSeconds(_waitTime);
        Damagable = true;
    }
    public void callInvunrable(float time) {
        coroutine = InVunrable(time);
        StartCoroutine(coroutine);
    }
    
}
