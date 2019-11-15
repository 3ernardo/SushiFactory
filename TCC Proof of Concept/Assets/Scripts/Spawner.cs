using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform foodPrefab;
    public Transform spawnPoint;
    public float spawnTimerInterval = 5f;
    private float countdown;

    void spawnFood() {
        Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        countdown = spawnTimerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f) {
            spawnFood();
            countdown = spawnTimerInterval;
        }
        countdown -= Time.deltaTime;
    }
}
