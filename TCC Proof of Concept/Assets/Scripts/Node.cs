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

    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown() {
        if (!PlayerWallet.instance.checkForCredit(10f)) {
            Debug.Log("Falha: Fundos insuficientes.");
            return;
        } else if (machine != null) {
            Debug.Log("Falha: Já existe algo construído aqui.");
            return;
        }

        GameObject machineToBuild = BuildManager.instance.GetMachineToBuild();
        machine = (GameObject)Instantiate(machineToBuild, transform.position + positionOffset, transform.rotation);

        BuildManager.instance.subtractMoney(10f);
        PlayerWallet.instance.removeMoney(10f);
    }

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
