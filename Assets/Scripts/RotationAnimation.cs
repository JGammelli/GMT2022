using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    public Quaternion cubeRot = new Quaternion(1, 0, 0, 0);
    public Quaternion cubeRotOrig = new Quaternion(1,0,0,0);
    public Quaternion cubeRotGoal = new Quaternion(0,0,0,1);
    public float tTime = 0;
    public int sign = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = new Quaternion(1, 0, 0, 0);
        cubeRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (tTime >= 1)
        {
            sign = -1;
        }
        else if (tTime < 0)
        {
            sign = 1;
        }
        tTime =tTime + sign*Time.deltaTime;
        cubeRot = Quaternion.Slerp(cubeRotOrig, cubeRotGoal, tTime);
        transform.rotation = cubeRot;
    }
}
