using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    private float playerPoints;
    public float scoreGoal = 40f;
    private bool playerHasWon;
    public Text scoreGoalText;

    void Awake() {
        instance = this;
    }

    void Start(){
        string sG = scoreGoal.ToString();
        scoreGoalText.text = sG;
    }

    public float getPoints(){
        return playerPoints;
    }

    public bool getVictoryStatus(){
        return playerHasWon;
    }

    public void setPoints(float value) {
        playerPoints = value;
    }

    public void checkVictoryStatus() {
        if (playerPoints >= scoreGoal) {
            playerHasWon = true;
        } else {
            playerHasWon = false;
        }
    }

    public void addPoints(float value) {
        if (value > 0) {
            playerPoints = playerPoints + value;
        } else {
            Debug.Log("Erro: Tentativa de adição de valor zero ou inferior.");
        }
    }
}
