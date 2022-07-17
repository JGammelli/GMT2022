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
    public Matrix4x4 mStart;
    private Transform tGoal;
    private Vector3 rotateDir;
    private bool DoRotate = false;

    // Start is called before the first frame update
    void Start()
    {

        cam.transform.LookAt(targetObject);
        startRot = targetObject.rotation;
        //endRot = startRot * new Quaternion(0, 0, 0.7071068f, 0.7071068f);
        mStart = targetObject.transform.worldToLocalMatrix;
        tGoal = targetObject;
    }

    // Update is called once per frame
    void Update()
    {
        mStart = targetObject.transform.worldToLocalMatrix;
        if (!inAnim && DoRotate) {
            startRot = targetObject.rotation;
            inAnim = true;
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    Vector3 rotateAmount = new Vector3(0f,0f,-90f);
            //    tGoal.Rotate(rotateAmount, Space.World);
            //    endRot = tGoal.rotation;
            //    //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z - 90);
            //    //endRot = startRot * new Quaternion(0, 0, 0.7071068f, 0.7071068f);
            //    startTime = Time.time;
            //    inAnim = true;

            //}
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    Vector3 rotateAmount = new Vector3(0f, 0f, +90f);
            //    tGoal.Rotate(rotateAmount, Space.World);
            //    endRot = tGoal.rotation;
            //    //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z + 90);
            //    //endRot = startRot * new Quaternion(0, 0, -0.7071068f, 0.7071068f);
            //    startTime = Time.time;
            //    inAnim = true;
            //}
            //else if (Input.GetKeyDown(KeyCode.W))
            //{
            //    Vector3 rotateAmount = new Vector3(90f, 0f, 0f);
            //    tGoal.Rotate(rotateAmount, Space.World);
            //    endRot = tGoal.rotation;
            //    //endRot = Quaternion.Euler(startRot.eulerAngles.x + 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
            //    //endRot = startRot * new Quaternion(0.7071068f, 0, 0, 0.7071068f);
            //    startTime = Time.time;
            //    inAnim = true;
            //}
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    Vector3 rotateAmount = new Vector3(-90f, 0f, 0f);
            //    tGoal.Rotate(rotateAmount, Space.World);
            //    endRot = tGoal.rotation;
            //    //endRot = Quaternion.Euler(startRot.eulerAngles.x - 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
            //    //endRot = endRot * startRot * new Quaternion(-0.7071068f, 0, 0, 0.7071068f);
            //    startTime = Time.time;
            //    inAnim = true;
            //}

        }
        if (DoRotate && inAnim) {
            targetObject.rotation = Quaternion.Slerp(startRot, endRot, (Time.time - startTime) * 2f);
            
            if (targetObject.rotation == endRot)
            {
                inAnim = false;
                DoRotate = false;
            }
        }

        rotation = targetObject.rotation;
    }

    bool RotateDie(int direction, float speed)
    {
        if (direction == 1 && !inAnim)
        {
            rotateDir = new Vector3(0f, 0f, -90f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 2 && !inAnim)
        {
            rotateDir = new Vector3(0f, 0f, 90f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 3 && !inAnim)
        {
            rotateDir = new Vector3(90f, 0f, 0f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 4 && !inAnim)
        {
            rotateDir = new Vector3(-90f, 0f, 0f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        return false;
    }
}
