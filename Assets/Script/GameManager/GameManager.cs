using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerStartTile;


    [Header("PowerUps")]
    [SerializeField] private int powerUpCount;
    [SerializeField] private float powerUpCooldown;
    private float lastNewPowerUps;




    public List<Tile> TileList = new List<Tile>();
    public List<Tile> PowerTilesList = new List<Tile>();


    [SerializeField] private Player _Player;


    private void Update()
    {
        if (Time.time > powerUpCooldown + lastNewPowerUps)
        {
            SpawnNewPowerUps();
        }
    }




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

    private void SpawnNewEnemies()
    {

    }

    private void SpawnNewPowerUps()
    {
        lastNewPowerUps = Time.time;
        for (int i = 0; i < powerUpCount; i++)
        {
            int y = Random.Range(0, TileList.Count);
            TileList[y].MakePowerTile();
            PowerTilesList.Add(TileList[y]);
        }
    }
}
