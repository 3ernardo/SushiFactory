using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{

    // private void OnCollisionEnter(Collision other) {
    private void OnTriggerStay(Collider other) {
        Debug.Log("Objeto sobre a máquina, " + other.gameObject.name);
        Destroy(other.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
