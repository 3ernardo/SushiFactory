using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public void setTarget (Node t) {
        this.target = t;
        transform.position = target.getBuildPosition();
        ui.SetActive(true);
    }

    public void hide() {
        ui.SetActive(false);
    }

    public void Sell ()
	{
		target.sellMachine();
		BuildManager.instance.deselectNode();
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
