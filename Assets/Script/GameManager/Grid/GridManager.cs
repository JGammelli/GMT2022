using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _Width, _Height;
    [SerializeField] private float _CellSize;
    [SerializeField] private Transform _GridStartPos;

    [SerializeField] private GameObject _TilePrefab;
    private GameManager _GameManager;





    private void Start()
    {
        _GameManager = GetComponent<GameManager>();
        InitializeGrid();
    }

    public void InitializeGrid()
    {
        int tileValue = 1;
        for (int h = 0; h < _Height; h++)
        {
            for (int w = 0; w < _Width; w++)
            {
                var tile = GameObject.Instantiate(_TilePrefab, Vector2.zero, Quaternion.identity);
                tile.GetComponent<Tile>().InitializeTile(GetTilePosition(w, h), tileValue);
                _GameManager.TileList.Add(tile.GetComponent<Tile>());
                tileValue++;
            }
        }

        _GameManager.SetPlayerOnGrid();

    }

    private Vector2 GetTilePosition(int w, int h)
    {
        return new Vector2(w + 0.5f, -(h + 0.5f)) * _CellSize + (Vector2)_GridStartPos.position;
    }
}
