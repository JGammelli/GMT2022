using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isPowerTile;
    public bool powerUsed;
    public int powerValue;

    public int tileNr;
    public int tileW;
    public int tileH;

    public SpriteRenderer sr;
    public Color powerColor;
    public Color defaultColor;

    public void InitializeTile(Vector2 position, int value)
    {
        tileNr = value;
        transform.position = position;
    }

    public void MakePowerTile()
    {
        isPowerTile = true;
        powerUsed = false;
        powerValue = Random.Range(1, 6);
        sr.color = powerColor;
    }

    public void RemovePowerTile()
    {
        isPowerTile = false;
        sr.color = defaultColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        Player player = collision.gameObject.GetComponent<Player>();
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

        if (player != null && playerMovement != null && isPowerTile)
        {
            if (playerMovement._Put && !powerUsed)
            {
                powerUsed = true;
                player.PowerUp();
                RemovePowerTile();
            }
        }
    }
}
