using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProjector : MonoBehaviour
{
    public Transform targetObject;
    public Camera cam;
    public Quaternion rotation;
    private Quaternion startRot;
    private Quaternion endRot;
    public float speed = 10f;
    private bool inAnim = false;
    private float startTime;
    private Quaternion targetRot;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.LookAt(targetObject);
        startRot = targetObject.rotation;
        endRot = startRot * new Quaternion(0, 0, 0.7071068f, 0.7071068f);

    }

    // Update is called once per frame
    void Update()
    {
        if (true) {
            
            startRot = targetObject.rotation;
            if (Input.GetKeyDown(KeyCode.D))
            {
                //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z - 90);
                endRot = startRot * new Quaternion(0, 0, 0.7071068f, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z + 90);
                endRot = startRot * new Quaternion(0, 0, -0.7071068f, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                //endRot = Quaternion.Euler(startRot.eulerAngles.x + 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
                endRot = startRot * new Quaternion(0.7071068f, 0, 0, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //endRot = Quaternion.Euler(startRot.eulerAngles.x - 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
                endRot = endRot * startRot * new Quaternion(-0.7071068f, 0, 0, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }

        }
        if (true) {
            targetObject.rotation = Quaternion.Slerp(startRot, endRot, (Time.time - startTime) * 2f);
            if (targetObject.rotation == endRot)
            {
                inAnim = false;
            }
        }

        rotation = targetObject.rotation;
    }
}
