using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   
    private IEnumerator coroutine;
    private bool pause = false;
    GameObject player;
    public GameObject pausebtn;
    public GameObject playbtn;
    public GameObject pauseText;
    public GameObject Menu;
    public GameObject Restart;
    public GameObject youDied;
    public GameObject AdNotWorking;
    public static bool FloorIsLava;
    private long ClassicScore;
    private long FILScore;


    private void Start()
    {
        player = GameObject.Find("Player");
        //FloorIsLava = Player_Move.FloorIsLava;
        pause = false;
        pausebtn.SetActive(true);
        playbtn.SetActive(false);
        pauseText.SetActive(false);
        Menu.SetActive(false);
        Restart.SetActive(false);
        youDied.SetActive(false);
        AdNotWorking.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartClassic()
    {
        SceneManager.LoadScene("Game");
        Score.scoreAmount = 0;
        FIL.FloorIsLava= false;
    }
    public void StartFIL() {
        SceneManager.LoadScene("FloorIsLava");
        Countup.time = 0f;
        Countup.End=false;
        FIL.FloorIsLava = true;
    }

    public void GameOver()
    {
        ClassicScore = (long)Score.scoreAmount;
        PlayGamesScript.AddScoreToLeaderBoard(GPGSIds.leaderboard_classic, ClassicScore);
        player.GetComponent<Player_Move>().isDeath = true;
        coroutine = DeathEnding(1.1f);
        StartCoroutine(coroutine);
    }
    IEnumerator DeathEnding(float _waitTime)
    {
        FindObjectOfType<Health>().callInvunrable(5f);
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene("GameOver");
    }

    public void GameOverFil() {
        Countup.End = true;
        FILScore = (long)Countup.time;
        PlayGamesScript.AddScoreToLeaderBoard(GPGSIds.leaderboard_floor_is_lava, FILScore);
        player.GetComponent<Player_Move>().isDeath = true;
        coroutine = DeathEndingFil(1.1f);
        StartCoroutine(coroutine);
    }
    IEnumerator DeathEndingFil(float _waitTime)
    {
        FindObjectOfType<Health>().callInvunrable(5f);
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene("GameOverFIL");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Scoreboard()
    {
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Died() {
        if (FIL.FloorIsLava == true) {
            Countup.End = true;
        }
        
        youDied.SetActive(true);
        pausebtn.SetActive(false);
        Time.timeScale = 0;
    }
    public void PlayAd() {
        FindObjectOfType<UnityMonitization>().DisplayVideoAD();
    }
    public void cantPlayAd() {
        AdNotWorking.SetActive(true);
    }
    public void Revive() {
        player.GetComponent<Health>().health += 2;
        if (FIL.FloorIsLava == true)
        {
            Countup.End = false;
        }
        FindObjectOfType<Health>().lastChance=true;
        youDied.SetActive(false);
        AdNotWorking.SetActive(false);
        Time.timeScale = 1;
        pausebtn.SetActive(true);
        player.GetComponent<Health>().callInvunrable(2f);
    }
    public void contiunue() {
        Time.timeScale = 1;
        youDied.SetActive(false);
        AdNotWorking.SetActive(false);
        if (FIL.FloorIsLava == false) {
            GameOver();
        }
        else if (FIL.FloorIsLava == true) {
            GameOverFil();
        }
        
    }

    public void pauseGame(bool varPause)
    {
        pause = varPause;
        if (pause == false) {
            Time.timeScale = 1;
            pausebtn.SetActive(true);
            playbtn.SetActive(false);
            pauseText.SetActive(false);
            Menu.SetActive(false);
            Restart.SetActive(false);
        }
        else if (pause == true)
        {
            Time.timeScale = 0;
            playbtn.SetActive(true);
            pausebtn.SetActive(false);
            pauseText.SetActive(true);
            Menu.SetActive(true);
            Restart.SetActive(true);
        }
    }
    public void ExitClassic() {
        Time.timeScale = 1;
        pausebtn.SetActive(true);
        playbtn.SetActive(false);
        pauseText.SetActive(false);
        Menu.SetActive(false);
        Restart.SetActive(false);
        GameOver();
    }
    public void ExitFIL()
    {
        Time.timeScale = 1;
        pausebtn.SetActive(true);
        playbtn.SetActive(false);
        pauseText.SetActive(false);
        Menu.SetActive(false);
        Restart.SetActive(false);
        GameOverFil();
    }
}
