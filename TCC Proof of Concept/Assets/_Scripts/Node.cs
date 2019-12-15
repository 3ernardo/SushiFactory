using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private GameObject machine;
    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;

    private Renderer rend;
    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown() {
        if (!PlayerWallet.instance.checkForCredit(10f)) {
            Debug.Log("Falha: Fundos insuficientes.");
            return;
        } else if (machine != null) {
            Debug.Log("Este tile já tem uma construção!");
            buildManager.selectNode(this);
            return;
        }

        GameObject machineToBuild = buildManager.GetMachineToBuild();
        machine = (GameObject)Instantiate(machineToBuild, transform.position + positionOffset, transform.rotation);

        // buildManager.subtractMoney(10f);
        PlayerWallet.instance.removeMoney(buildManager.GetMachineToBuildValue());
    }

    public void sellMachine() {
        PlayerWallet.instance.addMoney(5f);
        Destroy(machine);
    }

    public Vector3 getBuildPosition() {
		return transform.position + positionOffset;
	}

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
