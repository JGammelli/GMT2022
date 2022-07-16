using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public Transform targetPosition;
    [SerializeField] public float speed = 0.01f;
    private Vector2 directionVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        directionVector = (targetPosition.position - transform.position);
        
        if (directionVector.magnitude > 1)
        {
            directionVector.Normalize();
            transform.position += new Vector3(directionVector.x * speed/60, directionVector.y * speed/60, 0);
            print(directionVector);
            if (directionVector.y == 0)
            {
                directionVector.y = 0.0001f;
            }
            int upOrDown = 1;
            if (directionVector.y < 0)
            {
                upOrDown = -1;
            }
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Acos(directionVector.x) * Mathf.Rad2Deg * upOrDown);
        }
        
    }
}
