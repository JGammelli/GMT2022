using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public int tileNr;
    public int tileW;
    public int tileH;

    public void InitializeTile(Vector2 position, int value)
    {
        tileNr = value;
        transform.position = position;
    }
}
