using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake() {
        instance = this;
    }

    public GameObject standardMachinePrefab;

    private void Start() {
        machineToBuild = standardMachinePrefab;
    }

    private GameObject machineToBuild;

    public GameObject GetMachineToBuild() {
        return machineToBuild;
    }

}
