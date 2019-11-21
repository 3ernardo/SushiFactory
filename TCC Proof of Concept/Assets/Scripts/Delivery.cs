using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    public float counter;

    private void OnTriggerStay(Collider other) {
        Debug.Log("Pedido entregue: " + other.gameObject.name);
        Destroy(other.gameObject);
        PlayerScore.instance.addPoints(10);
        counter++;
        Debug.Log("Número de pedidos entregues " + counter);
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
