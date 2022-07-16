using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _MoveSpeed;
    [SerializeField] private float _MaxDistanceToMoveObject;


    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    public Transform playerMoveObject;
    public List<Tile> MoveTileList = new List<Tile>();


    public Tile currentTile;
    public int currentTileNr;
    public int currentTileW;
    public int currentTileH;


    private void Awake()
    {
        playerMoveObject.parent = null;
        playerMoveObject.position = transform.position;
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");



        if (Vector2.Distance((Vector2)transform.position, (Vector2)playerMoveObject.position) <= _MaxDistanceToMoveObject)
        {
            if (Mathf.Abs(horizontalInput) == 1f)
            {
                for (int i = 0; i < MoveTileList.Count; i++)
                {
                    if (MoveTileList[i].tileH == currentTileH + horizontalInput)
                    {
                        playerMoveObject.position = MoveTileList[i].transform.position;
                        UpdateCurrentTile(MoveTileList[i]);

                    }
                }
            } else if (Mathf.Abs(verticalInput) == 1f)
            {
                for (int i = 0; i < MoveTileList.Count; i++)
                {
                    if (MoveTileList[i].tileW == currentTileW + verticalInput)
                    {
                        playerMoveObject.position = MoveTileList[i].transform.position;
                        UpdateCurrentTile(MoveTileList[i]);
                    }
                }
            }
        }


    }

    private void FixedUpdate()
    {
        Move();
    }


    private void UpdateCurrentTile(Tile tile)
    {
        currentTile = tile;
        currentTileNr = currentTile.tileNr;
        currentTileW = currentTile.tileW;
        currentTileH = currentTile.tileH;
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerMoveObject.position, _MoveSpeed * Time.fixedDeltaTime);
    }


}
