using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public int tileNr;

    public void InitializeTile(Vector2 position, int value)
    {
        tileNr = value;
        transform.position = position;
    }
}
