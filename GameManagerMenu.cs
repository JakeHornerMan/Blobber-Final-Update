using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerMenu : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject HiddenMenu;
    public GameObject howtoPlay;
    public GameObject noGPlay;
    //public static bool FloorIsLava;
    // Start is called before the first frame update
    void Start()
    {
        HiddenMenu.SetActive(false);
        howtoPlay.SetActive(false);
        noGPlay.SetActive(false);
    }

    public void StartClassic()
    {
        //SceneManager.LoadScene("Game");
        Score.scoreAmount = 0;
        //FIL.FloorIsLava = false;
        FindObjectOfType<FIL>().FilSetter(false);
        //FloorIsLava = false;
        FindObjectOfType<titleblue>().willRun = true;
        SoundManager.PlaySound("glassSmash");
        FindObjectOfType<menuBackground>().crack();
        coroutine = WaitandScream(0.3f);
        StartCoroutine(coroutine);
    }
    public void StartFIL()
    {
        FindObjectOfType<FIL>().FilSetter(true);
        Countup.End = false;
        FindObjectOfType<titleblue>().willRun = true;
        SoundManager.PlaySound("glassSmash");
        FindObjectOfType<menuBackground>().crack();
        coroutine = WaitandScream(0.3f);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitandScream(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        SoundManager.PlaySound("scream");
        if (FIL.FloorIsLava == true)
        {
            coroutine = WaitandPlayFIL(2f);
        }
        else if (FIL.FloorIsLava == false) {
            coroutine = WaitandPlayClassic(2f);
        }
        StartCoroutine(coroutine);
    }
    IEnumerator WaitandPlayClassic(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        Score.scoreAmount = 0;
        SceneManager.LoadScene("Game");
    }
    IEnumerator WaitandPlayFIL(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        Score.scoreAmount = 0;
        SceneManager.LoadScene("FloorIsLava");
    }

    public void HowToPlay() {
        howtoPlay.SetActive(true);
        FindObjectOfType<titleblue>().fade = 1;
        FindObjectOfType<howToPlay>().htpMENU(true);

    }
    public void HowToPlayCancel()
    {
        FindObjectOfType<titleblue>().fade = 2;
        FindObjectOfType<howToPlay>().htpMENU(false);
        coroutine = WaitandFade(1f);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitandFade(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        FindObjectOfType<titleblue>().fade = 0;
        howtoPlay.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Scoreboard()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }
    public void noScoreboard() {
        noGPlay.SetActive(true);
        coroutine = Waitandleave(3f);
        StartCoroutine(coroutine);
    }
    IEnumerator Waitandleave(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        noGPlay.SetActive(false);
    }

    public void titleStart()
    {
        HiddenMenu.SetActive(true);
        FindObjectOfType<HiddenMenu>().gameMenu(true);
    }
    
    public void titleStartCancel() {
        FindObjectOfType<HiddenMenu>().gameMenu(false);
        coroutine = WaitandFadeHM(1f);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitandFadeHM(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        HiddenMenu.SetActive(false);
    }
}
