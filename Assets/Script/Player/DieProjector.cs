using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProjector : MonoBehaviour
{
    public Transform targetObject;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.LookAt(targetObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
