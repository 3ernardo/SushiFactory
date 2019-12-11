using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text VictoryLossText;
    public Text finalScoreText;

    void OnEnable() {
        finalScoreText.text = (PlayerScore.instance.getPoints()).ToString();
        if (PlayerScore.instance.getVictoryStatus()) {
            VictoryLossText.text = "Victory!";
        } else {
            VictoryLossText.text = "Defeat!";
        }
    }
}
