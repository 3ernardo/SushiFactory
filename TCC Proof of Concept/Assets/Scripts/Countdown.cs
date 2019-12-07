using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float timer = 120f;
    private float timeLeft;
    public Text displayTimer;

    private void counter(){
        timeLeft -= Time.deltaTime;
        displayTimer.text = (timeLeft).ToString("0");
        // Debug.Log(timeLeft);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;
    }

    // Update is called once per frame
    void Update()
    {
        counter();
    }
}
