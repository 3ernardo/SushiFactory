using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    private float playerPoints;
    public float scoreGoal = 40f;

    void Awake() {
        instance = this;
    }

    public float getPoints(){
        return playerPoints;
    }

    public void setPoints(float value) {
        playerPoints = value;
    }

    public void addPoints(float value) {
        if (value > 0) {
            playerPoints = playerPoints + value;
        } else {
            Debug.Log("Erro: Tentativa de adição de valor zero ou inferior.");
        }
    }
}
