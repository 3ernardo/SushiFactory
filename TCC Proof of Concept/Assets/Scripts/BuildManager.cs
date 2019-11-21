using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public float PlayerMoney;
    public float playerScore;

    public Text PlayerMoneyCounter;
    public Text PlayerScoreCounter;

    public void subtractMoney(float value) {
        PlayerMoney = PlayerMoney - value;
    }
    void Awake() {
        instance = this;
    }

    public GameObject standardMachinePrefab;
    public GameObject advancedMachinePrefab;
    public GameObject basicMachinePrefab;
    public GameObject conveyorRightMachinePrefab;
    public GameObject conveyorUpMachinePrefab;
    public GameObject conveyorDownMachinePrefab;
    public GameObject conveyorLeftMachinePrefab;

    private void Start() {
        machineToBuild = standardMachinePrefab;
        // PlayerMoney = 100f;
        PlayerWallet.instance.setMoney(PlayerMoney);
        PlayerScore.instance.setPoints(playerScore);
    }

    void Update() {
        // PlayerMoneyCounter.text = Mathf.Floor(PlayerMoney).ToString();
        PlayerMoneyCounter.text = Mathf.Floor(PlayerWallet.instance.getMoney()).ToString();
        PlayerScoreCounter.text = Mathf.Floor(PlayerScore.instance.getPoints()).ToString();
    }

    public void ChangeMachineConveyorRight() {
        machineToBuild = conveyorRightMachinePrefab;
    }
    public void ChangeMachineConveyorUp() {
        machineToBuild = conveyorUpMachinePrefab;
    }
    public void ChangeMachineConveyorDown() {
        machineToBuild = conveyorDownMachinePrefab;
    }
    public void ChangeMachineConveyorLeft() {
        machineToBuild = conveyorLeftMachinePrefab;
    }
    
    public void ChangeMachineStandard() {
        machineToBuild = standardMachinePrefab;
    }
    public void ChangeMachineAdvanced() {
        machineToBuild = advancedMachinePrefab;
    }
    public void ChangeMachineBasic() {
        machineToBuild = basicMachinePrefab;
    }

    private GameObject machineToBuild;

    public GameObject GetMachineToBuild() {
        return machineToBuild;
    }

}
