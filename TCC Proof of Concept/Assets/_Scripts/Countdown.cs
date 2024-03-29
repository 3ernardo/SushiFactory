﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public static Countdown instance;
    public GameObject gameOverUI;
    public GameObject destroyer;
    private bool isGameOver = false;
    public float timer = 120f;
    private float timeLeft;
    public Text displayTimer;
    PlayerScore playerScore;


    private void counter(){
        timeLeft -= Time.deltaTime;
        // displayTimer.text = (timeLeft).ToString("0");
        displayTimer.text = minutes()+":"+seconds();
        if (timeLeft <= 0) {
            triggerGameOver();
        }
        // Debug.Log(timeLeft);
    }

    private string minutes() {
        string minutes = ((int)timeLeft/60).ToString("0");
        if (minutes.Length < 2) {
            minutes = minutes.PadLeft(2, '0');
        }
        return minutes;
    }

    private string seconds() {
        string seconds = ((int)timeLeft%60).ToString("0");
        if (seconds.Length < 2) {
           seconds = seconds.PadLeft(2, '0');
        }
        return seconds;
    }

    private void triggerGameOver() {
        isGameOver = true;
        playerScore.checkVictoryStatus();
        gameOverUI.SetActive(true);
        destroyer.SetActive(true);
        // if (playerScore.getPoints() >= playerScore.scoreGoal) {
        //     Debug.Log("Parabéns! Você venceu.");
        // } else {
        //     Debug.Log("Infelizmente você não conseguiu.");
        // }
    }

    public bool GetGameOver() {
        return isGameOver;
    }
    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;
        playerScore = PlayerScore.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            counter();
        }
    }
}
