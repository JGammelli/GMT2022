using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] public Transform directionVector;
    [SerializeField] public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = directionVector.rotation;
        //if (directionVector.position.y == 0)
        //    directionVector.position = new Vector3(directionVector.position.x, 0.0001f, 0);
        //int upOrDown = 1;
        //if (directionVector.position.y < 0)
        //    upOrDown = -1;

        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(directionVector.position.x) * Mathf.Rad2Deg * upOrDown);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += new Vector3(directionVector.rotation.eulerAngles * speed / 60, directionVector.y * speed / 60, 0);
    }
}
