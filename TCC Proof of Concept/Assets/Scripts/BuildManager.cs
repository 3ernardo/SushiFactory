using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake() {
        instance = this;
    }

    public GameObject standardMachinePrefab;
    public GameObject advancedMachinePrefab;
    public GameObject basicMachinePrefab;

    private void Start() {
        machineToBuild = standardMachinePrefab;
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
