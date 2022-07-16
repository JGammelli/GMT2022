using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    public void InitializePlayer(Vector2 pos)
    {
        transform.position = pos;
    }

}