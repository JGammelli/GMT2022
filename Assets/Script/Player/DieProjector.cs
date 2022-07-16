using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProjector : MonoBehaviour
{
    public Transform targetObject;
    public Camera cam;
    public Quaternion rotation;
    private Quaternion startRot;
    public float speed = 10f;
    private bool inAnim = false;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.LookAt(targetObject);
        startRot = targetObject.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !inAnim) {
            inAnim = true;
            startTime = Time.time;
        }
        if (inAnim) {
            targetObject.rotation = Quaternion.Lerp(new Quaternion(0, 0, 0, 1), new Quaternion(0, 0, 0.7071068f, 0.7071068f), (Time.time - startTime) * 1f);
            if (targetObject.rotation == new Quaternion(0, 0, 0.7071068f, 0.7071068f))
            {
                inAnim = false;
            }
        }

        rotation = targetObject.rotation;
    }
}
