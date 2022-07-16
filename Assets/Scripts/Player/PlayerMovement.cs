using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    private float horizontalDir;
    private float verticalDir;
    private Vector3 dir;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");



    }

    private void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        horizontalDir = 0;
        verticalDir = 0;
        if (Mathf.Abs(horizontalInput) == 1f)
        {
            horizontalDir = horizontalInput;
        }
        else if ((Mathf.Abs(verticalInput) == 1f))
        {
            verticalDir = verticalInput;
        }


        dir = new Vector3(horizontalDir, verticalDir, 0);
        rb.velocity = dir * moveSpeed;
    
    }
}
