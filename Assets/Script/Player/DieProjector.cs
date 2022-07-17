using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProjector : MonoBehaviour
{
    [SerializeField] public Transform rayBox;
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
    private bool DoRotate = true;
    

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
        if (!inAnim) {
            startRot = targetObject.rotation;
            if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 rotateAmount = new Vector3(0f, 0f, -90f);
                tGoal.Rotate(rotateAmount, Space.World);
                endRot = tGoal.rotation;
                //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z - 90);
                //endRot = startRot * new Quaternion(0, 0, 0.7071068f, 0.7071068f);
                startTime = Time.time;
                inAnim = true;

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Vector3 rotateAmount = new Vector3(0f, 0f, +90f);
                tGoal.Rotate(rotateAmount, Space.World);
                endRot = tGoal.rotation;
                //endRot = Quaternion.Euler(startRot.eulerAngles.x, startRot.eulerAngles.y, startRot.eulerAngles.z + 90);
                //endRot = startRot * new Quaternion(0, 0, -0.7071068f, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Vector3 rotateAmount = new Vector3(90f, 0f, 0f);
                tGoal.Rotate(rotateAmount, Space.World);
                endRot = tGoal.rotation;
                //endRot = Quaternion.Euler(startRot.eulerAngles.x + 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
                //endRot = startRot * new Quaternion(0.7071068f, 0, 0, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Vector3 rotateAmount = new Vector3(-90f, 0f, 0f);
                tGoal.Rotate(rotateAmount, Space.World);
                endRot = tGoal.rotation;
                //endRot = Quaternion.Euler(startRot.eulerAngles.x - 90, startRot.eulerAngles.y, startRot.eulerAngles.z);
                //endRot = endRot * startRot * new Quaternion(-0.7071068f, 0, 0, 0.7071068f);
                startTime = Time.time;
                inAnim = true;
            }
        }
        if (inAnim) {
            targetObject.rotation = Quaternion.Slerp(startRot, endRot, (Time.time - startTime) * 2f);
            
            if (targetObject.rotation == endRot)
            {
                inAnim = false;
                //DoRotate = false;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            getUp(); // remove this thing
        }
        
        rotation = targetObject.rotation;
    }

    bool RotateDie(int direction, float speed)
    {
        if (direction == 1 && !inAnim) // Right
        {
            rotateDir = new Vector3(0f, 0f, -90f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 2 && !inAnim) // Left
        {
            rotateDir = new Vector3(0f, 0f, 90f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 3 && !inAnim) // Up
        {
            rotateDir = new Vector3(90f, 0f, 0f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        if (direction == 4 && !inAnim) // Down
        {
            rotateDir = new Vector3(-90f, 0f, 0f);
            tGoal.Rotate(rotateDir, Space.World);
            endRot = tGoal.rotation;
            DoRotate = true;
            return true;
        }
        return false;
    }

    int getUp()
    {
        var raypos = rayBox.position;
        var raydir = rayBox.up;
        RaycastHit hit;
        if (Physics.Raycast(raypos, raydir, out hit))
        {
            var box = hit.transform;
            if (box.CompareTag("6"))
            {
                print("6 IS UP");
                return 6;
            }
            if (box.CompareTag("5"))
            {
                print("5 IS UP");
                return 5;
            }
            if (box.CompareTag("4"))
            {
                print("4 IS UP");
                return 4;
            }
            if (box.CompareTag("3"))
            {
                print("3 IS UP");
                return 3;
            }
            if (box.CompareTag("2"))
            {
                print("2 IS UP");
                return 2;
            }
            if (box.CompareTag("1"))
            {
                print("1 IS UP");
                return 1;
            }
        }
        return 0;
    }
}
