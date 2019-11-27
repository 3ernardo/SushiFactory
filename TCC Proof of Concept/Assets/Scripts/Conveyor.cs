using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed = 1f;
    public float beltAnimSpeed = 1f;
    public SkinnedMeshRenderer beltBand;

    private void OnTriggerStay(Collider other) {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
    }

    void Update () {
        float offset = Time.time * beltAnimSpeed;
        beltBand.material.SetTextureOffset("_MainTex", new Vector2 (0, offset));
    }
}