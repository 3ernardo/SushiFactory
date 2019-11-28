using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    public float counter;
    // public ParticleSystem deliveryParticle;
    public GameObject successEffectsGO;
    public GameObject floatingTextPrefab;
    public Transform effectsOrigin;

    // private void checkWhatWasDelivered(string delivered) {
    //     // Debug.Log("Pedido entregue: " + delivered.Contains("Nigiri"));
    //     if (delivered.Contains("Nigiri")) {
    //         Debug.Log("Nigiri entregue!");
    //         PlayerScore.instance.addPoints(20);
    //     } else if (delivered.Contains("Temaki")) {
    //         Debug.Log("Temaki entregue!");
    //         PlayerScore.instance.addPoints(30);
    //     } else if (delivered.Contains("Maki")) {
    //         Debug.Log("Maki entregue!");
    //         PlayerScore.instance.addPoints(10);
    //     } else {
    //         Debug.Log("Nem ideia do que foi entregue!");
    //     }
    // }

    private void addFoodPunctuation(GameObject deliveredObject) {
        float deliveredPoints = deliveredObject.GetComponents<Food>()[0].points;
        PlayerScore.instance.addPoints(deliveredPoints);
        successFeedback(deliveredPoints);
    }

    private void testComponent(GameObject toTest) {
        Component[] components = toTest.GetComponents(typeof(Component));
        Debug.Log("<<<<<<<");
        foreach(Component component in components) {
            Debug.Log(component.ToString());
        }
        Debug.Log(">>>>>>>");
    }

    private void successFeedback(float pointsAwarded) {
        GameObject successParticles = Instantiate(successEffectsGO, effectsOrigin.position, Quaternion.identity);
        GameObject displayPoints = Instantiate(floatingTextPrefab, effectsOrigin.position, Quaternion.identity);
        displayPoints.GetComponent<TMPro.TextMeshPro>().text = ("+" + pointsAwarded.ToString());
        // testComponent(displayPoints);
        Destroy(successParticles, 2f);
        // Destroy(displayPoints, 1f);
    }

    private void OnTriggerStay(Collider other) {
        // deliveryParticle.Play();
        // Debug.Log(">>>>>>>>>>>>> " + other.gameObject.GetComponents(typeof(Component)));
        // Debug.Log(">>>>>>>>>>>>> " + other.gameObject.GetComponents<Food>()[0].points);
        // testComponent(other.gameObject);
        addFoodPunctuation(other.gameObject);
        // successFeedback();
        // checkWhatWasDelivered(other.gameObject.name);
        Debug.Log("Pedido entregue: " + other.gameObject.name);
        Destroy(other.gameObject);
        counter++;

        // GameObject successEffects = Instantiate(successEffectsGO, new Vector3(2f, 2f, 2f), Quaternion.identity);
        // Debug.Log("Número de pedidos entregues " + counter);
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
