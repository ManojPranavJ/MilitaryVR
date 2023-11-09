using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float GameTime;
    private float CurrentFillAmount = 1f;
    [SerializeField] private TextMeshProUGUI score;

    private int PlayerScore;


    [SerializeField] private GameObject Gameover;

    [SerializeField] private TextMeshProUGUI Highscore;
    private int highscore;

    [SerializeField]private AudioSource AudioSource;
    [SerializeField] private AudioClip[] startAudio;

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }
    public static GameState CurrentGameStatus;




    private void Awake()
    {
       

        

        CurrentGameStatus = GameState.Waiting;



        if (PlayerPrefs.HasKey("HighScore"))
        {
            Highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }       
    }

    void Update()
    {
        if (CurrentGameStatus == GameState.Playing)
        Timer();
        
    }

    private void Timer()
    {
        timerImage.fillAmount = CurrentFillAmount - (Time.deltaTime / GameTime);

        CurrentFillAmount = timerImage.fillAmount;
        if(CurrentFillAmount <= 0 )
        {
            GameOver();
        }

    }
    public void UpdatePlayerScore(int AsteroidHitScore)
    {
        if(CurrentGameStatus != GameState.Playing) { return; }
        PlayerScore += AsteroidHitScore;
        score.text = PlayerScore.ToString();
    }
    public void StartGame()
    {
        CurrentGameStatus = GameState.Playing;
        AudioSource.clip = startAudio[1];
        AudioSource.Play();
    }

    public void GameOver()
    {
        CurrentGameStatus = GameState.GameOver;


        Gameover.SetActive(true);

        if( PlayerScore > PlayerPrefs.GetInt("HighScore" ) )
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);

            Highscore.text = PlayerScore.ToString();
        }

        AudioSource.clip = startAudio[2];
        AudioSource.Play();
        AudioSource.loop = false;
    }

    public void resetGame()
    {
        CurrentGameStatus = GameState.Waiting;


        //timer reset

        CurrentFillAmount = 1f;
        timerImage.fillAmount = 1f;


        // score reset
        PlayerScore = 0;
        score.text = "o";


        AudioSource.clip = startAudio[0];
        AudioSource.Play();
    }
    

}
