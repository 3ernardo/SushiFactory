using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public float PlayerMoney;

    public Text PlayerMoneyCounter;

    public void subtractMoney(float value) {
        PlayerMoney = PlayerMoney - value;
    }
    void Awake() {
        instance = this;
    }

    public GameObject standardMachinePrefab;
    public GameObject advancedMachinePrefab;
    public GameObject basicMachinePrefab;

    private void Start() {
        machineToBuild = standardMachinePrefab;
        PlayerMoney = 100f;
        PlayerWallet.instance.setMoney(80f);
    }

    void Update() {
        // PlayerMoneyCounter.text = Mathf.Floor(PlayerMoney).ToString();
        PlayerMoneyCounter.text = Mathf.Floor(PlayerWallet.instance.getMoney()).ToString();
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
