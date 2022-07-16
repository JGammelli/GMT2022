using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;



    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }
    public void InitializePlayer(Vector2 pos, List<Tile> tileList, Tile currentTile)
    {
        transform.position = pos;
        playerMovement.playerMoveObject.position = pos;
        playerMovement.MoveTileList = tileList;
        playerMovement.currentTile = currentTile;
        playerMovement.currentTileNr = playerMovement.currentTile.tileNr;
        playerMovement.currentTileW = playerMovement.currentTile.tileW;
        playerMovement.currentTileH = playerMovement.currentTile.tileH;
    }

}