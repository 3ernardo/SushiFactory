using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 1f;
    // public Vector3 rotation = new Vector3(35.0f, 30.0f, 20.0f);
    // public Vector3 rotation = new Vector3(0f, 0f, 180f);
    public Vector3 offset = new Vector3(0, 2, 0);
    public Vector3 randomizePosition = new Vector3(0.7f, 0.4f, 0);
    // private GameObject cam;

    // void Awake ()
    // {
    //     cam = GameObject.FindGameObjectWithTag("MainCamera");
    // }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        // transform.LookAt(cam.transform);
        // transform.rotation = Quaternion.Slerp(transform.rotation, cam, Time.deltaTime);
        // transform.Rotate(0.0f, 0.0f, -20.0f);
        // transform.Rotate(rotation);
        // transform.Rotate(rotation, Space.Self);
        transform.Rotate(35.0f, 30.0f, 20.0f, Space.Self);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(
            Random.Range(-randomizePosition.x, randomizePosition.x),
            Random.Range(-randomizePosition.y, randomizePosition.y),
            Random.Range(-randomizePosition.z, randomizePosition.z)
        );
    }
}
