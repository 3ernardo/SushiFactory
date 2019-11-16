using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public float counter;
    public Transform prefabToSpawn;
    public Transform spawnPoint;

    // private void OnCollisionEnter(Collision other) {
    private void OnTriggerStay(Collider other) {
        Debug.Log("Objeto sobre a máquina, " + other.gameObject.name);
        Destroy(other.gameObject);
        counter++;
        Debug.Log("Número de caixas destruídas " + counter);
        if (counter > 2) {
            gotEnoughBoxes();
        }
    }

    private void gotEnoughBoxes() {
        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawn a new box!");
        counter = 0;
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
