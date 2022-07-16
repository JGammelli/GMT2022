using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerStartTile;
    public List<Tile> TileList = new List<Tile>();


    [SerializeField] private Player _Player;
  
   

    private Tile GetStartTile()
    {
        var startTile = TileList[0];
        for (int i = 0; i < TileList.Count; i++)
        {
            if (playerStartTile == TileList[i].tileNr)
            {
                startTile = TileList[i];
            }
        }
        return startTile;
    }

    public void SetPlayerOnGrid()
    {
        _Player.InitializePlayer(GetStartTile().transform.position, TileList, GetStartTile());
    }
}
