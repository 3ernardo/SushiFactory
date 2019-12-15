using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public bool isAssembler;
    public bool isSlicer;
    public bool isCooker;

    private int counter = 0;
    public int amountNeeded;
    public Transform prefabToSpawn;
    public Transform spawnPoint;
    
    private int sashimiStored;
    private int cookedRiceStored;
    private int noriStored;

    private ArrayList ingredientesContidos = new ArrayList();

    // private void OnCollisionEnter(Collision other) {
    private void OnTriggerStay(Collider other) {
        // Debug.Log("Objeto sobre a máquina: " + other.gameObject.name);
        // Debug.Log("Tipo do objeto sobre a máquina: " + other.GetComponents<Food>()[0].type);
        addToLocalStorage(other.GetComponents<Food>()[0].type);
        registerAndDestroy(other.gameObject);
        // Destroy(other.gameObject);
        counter++;
        // Debug.Log("Número de caixas destruídas " + counter);
        // if (counter >= amountNeeded) {
        //     gotEnoughBoxes();
        // }
        // Debug.Log("Sashimi " + sashimiStored + "CookedRice " + cookedRiceStored + "Nori " + noriStored);
        ArrayList myList = new ArrayList();
        myList.Add("Nori");
        myList.Add("Sashimi");
        Debug.Log("Sashimi e Nori? " + checkMaterialsForRecipe(myList));
    }

    private void registerAndDestroy(GameObject go) {
        string foodType =  go.GetComponents<Food>()[0].type;
        ingredientesContidos.Add(foodType);
        Destroy(go.gameObject);
        if (isAssembler) {
            AssemblerMechanics();
        } else if (isSlicer) {
            if (foodType == "Fish") {
                SlicerOrCookerMechanics();
            }
        } else if (isCooker) {
            if (foodType == "Rice") {
                SlicerOrCookerMechanics();
            }
        }
    }

    private void SlicerOrCookerMechanics() {
        gotEnoughBoxes();
    }

    private void AssemblerMechanics() {
        ArrayList temakiRecipe = new ArrayList();
        temakiRecipe.Add("Nori");
        temakiRecipe.Add("CookedRice");
        temakiRecipe.Add("Sashimi");
        if (checkMaterialsForRecipe(temakiRecipe)) {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            ingredientesContidos.Remove("Nori");
            ingredientesContidos.Remove("CookedRice");
            ingredientesContidos.Remove("Sashimi");
        }
    }

    private void addToLocalStorage(string f) {
        if (f == "Sashimi") { sashimiStored++; }
        if (f == "CookedRice") { cookedRiceStored++; }
        if (f == "Nori") { noriStored++; }
    }

    private bool checkMaterialsForRecipe(ArrayList ingredientes) {
        bool ingredienteEncontrado = false;
        for (int i = 0; i < ingredientes.Count; i++){
            for (int j = 0; j < ingredientesContidos.Count; j++) {
                if (string.Equals(ingredientes[i].ToString(), ingredientesContidos[j].ToString())){
                    ingredienteEncontrado = true;
                }
            }
            // (ingredienteEncontrado) ? ingredienteEncontrado = false : return false;
            if (!ingredienteEncontrado) {
                return false;
            } else {
                ingredienteEncontrado = false;
            }
        }
        return true;
    }

    private void gotEnoughBoxes() {
        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        // Debug.Log("Spawn a new box!");
        counter = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown.instance.GetGameOver()){
            prefabToSpawn = null;
        }
    }
}
