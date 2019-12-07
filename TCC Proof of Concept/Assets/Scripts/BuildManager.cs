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

    private GameObject machineToBuild;
    private Node selectedNode;
    public SelectUI selectUI;

    public GameObject GetMachineToBuild() {
        return machineToBuild;
    }

    public void setMachineToBuild(GameObject machine) {
        machineToBuild = machine;
        deselectNode();
    }

    public void selectNode (Node node) {
        if (selectedNode == node) {
            deselectNode();
            return;
        }
        selectedNode = node;
        machineToBuild = null;
        selectUI.setTarget(node);
    }

    public void deselectNode() {
        selectedNode = null;
        selectUI.hide();
    }

    private void Start() {
        machineToBuild = standardMachinePrefab;
        deselectNode();
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
        setMachineToBuild(conveyorRightMachinePrefab);
    }
    public void ChangeMachineConveyorUp() {
        setMachineToBuild(conveyorUpMachinePrefab);
    }
    public void ChangeMachineConveyorDown() {
        setMachineToBuild(conveyorDownMachinePrefab);
    }
    public void ChangeMachineConveyorLeft() {
        setMachineToBuild(conveyorLeftMachinePrefab);
    }
    public void ChangeMachineStandard() {
        setMachineToBuild(standardMachinePrefab);
    }
    public void ChangeMachineAdvanced() {
        setMachineToBuild(advancedMachinePrefab);
    }
    public void ChangeMachineBasic() {
        setMachineToBuild(basicMachinePrefab);
    }

}