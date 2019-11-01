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
        if (machine != null)
        {
            Debug.Log("Já existe algo construído aqui.");
            return;
        }

        GameObject machineToBuild = BuildManager.instance.GetMachineToBuild();
        machine = (GameObject)Instantiate(machineToBuild, transform.position + positionOffset, transform.rotation);

    }

    void OnMouseEnter() {
        rend.material.color = hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }
}
