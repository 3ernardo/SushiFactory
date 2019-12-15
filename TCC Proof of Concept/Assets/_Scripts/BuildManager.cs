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

    public GameObject spawnerFish;
    public GameObject spawnerNori;
    public GameObject spawnerRice;

    public GameObject standardMachinePrefab;
    public GameObject advancedMachinePrefab;
    public GameObject basicMachinePrefab;
    public GameObject conveyorRightMachinePrefab;
    public GameObject conveyorUpMachinePrefab;
    public GameObject conveyorDownMachinePrefab;
    public GameObject conveyorLeftMachinePrefab;
    
    public GameObject machineCooker;
    public GameObject machineAssembler;
    public GameObject MAchineSlicer;

    private GameObject machineToBuild;
    private Node selectedNode;
    public SelectUI selectUI;

    public GameObject beltDropDown;
    public GameObject machineDropDown;
    public GameObject spawnDropDown;
    public GameObject uiBlocker;

    public GameObject GetMachineToBuild() {
        return machineToBuild;
    }

    public float GetMachineToBuildValue() {
        if (machineToBuild == conveyorRightMachinePrefab ||
            machineToBuild == conveyorUpMachinePrefab ||
            machineToBuild == conveyorDownMachinePrefab ||
            machineToBuild == conveyorLeftMachinePrefab) {
            return 10f;
        } else {
            return 100f;
        }
    }

    public void setMachineToBuild(GameObject machine) {
        machineToBuild = machine;
        deselectNode();
    }

    // public void handleBeltDropDown(int i) {
    //     if (i == 0) {
    //         setMachineToBuild(conveyorUpMachinePrefab);
    //     }
    //     if (i == 1) {
    //         setMachineToBuild(conveyorDownMachinePrefab);
    //     }
    //     if (i == 2) {
    //         setMachineToBuild(conveyorRightMachinePrefab);
    //     }
    //     if (i == 3) {
    //         setMachineToBuild(conveyorLeftMachinePrefab);
    //     }
    // }

    public void switchButtonsBelt(){
        if (beltDropDown.activeSelf) {
            beltDropDown.SetActive(false);
        } else {
            beltDropDown.SetActive(true);
            uiBlocker.SetActive(true);
        }
    }

    public void switchButtonsMachine(){
        if (machineDropDown.activeSelf) {
            machineDropDown.SetActive(false);
        } else {
            machineDropDown.SetActive(true);
            uiBlocker.SetActive(true);
        }
    }

    public void switchButtonsSpawn(){
        if (spawnDropDown.activeSelf) {
            spawnDropDown.SetActive(false);
        } else {
            spawnDropDown.SetActive(true);
            uiBlocker.SetActive(true);
        }
    }

    public void hideDropDowns(){
        beltDropDown.SetActive(false);
        machineDropDown.SetActive(false);
        spawnDropDown.SetActive(false);
        uiBlocker.SetActive(false);
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
        machineToBuild = null;
        deselectNode();
        // PlayerMoney = 100f;
        PlayerWallet.instance.setMoney(PlayerMoney);
        PlayerScore.instance.setPoints(playerScore);
    }

    void Update() {
        // PlayerMoneyCounter.text = Mathf.Floor(PlayerMoney).ToString();
        PlayerMoneyCounter.text = "$" + " " + (Mathf.Floor(PlayerWallet.instance.getMoney()).ToString());
        PlayerScoreCounter.text = "P" + " " + (Mathf.Floor(PlayerScore.instance.getPoints()).ToString());
    }

    public void ChangeMachineConveyorRight() {
        setMachineToBuild(conveyorRightMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineConveyorUp() {
        setMachineToBuild(conveyorUpMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineConveyorDown() {
        setMachineToBuild(conveyorDownMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineConveyorLeft() {
        setMachineToBuild(conveyorLeftMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineStandard() {
        setMachineToBuild(standardMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineAdvanced() {
        setMachineToBuild(advancedMachinePrefab);
        hideDropDowns();
    }
    public void ChangeMachineBasic() {
        setMachineToBuild(basicMachinePrefab);
        hideDropDowns();
    }
    public void ChangeSpawnerFish() {
        setMachineToBuild(spawnerFish);
        hideDropDowns();
    }
    public void ChangeSpawnerNori() {
        setMachineToBuild(spawnerNori);
        hideDropDowns();
    }
    public void ChangeSpawnerRice() {
        setMachineToBuild(spawnerRice);
        hideDropDowns();
    }
    public void ChangeMachineCooker() {
        setMachineToBuild(machineCooker);
        hideDropDowns();
    }
    public void ChangeMachineSlicer() {
        setMachineToBuild(MAchineSlicer);
        hideDropDowns();
    }
    public void ChangeMachineAssembler() {
        setMachineToBuild(machineAssembler);
        hideDropDowns();
    }

}