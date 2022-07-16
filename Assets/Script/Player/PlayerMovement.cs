using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _MoveSpeed;
    [SerializeField] private float _MoveDistance;
    [SerializeField] private float _MaxDistanceToMoveObject;


    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private bool _Moving;
    [SerializeField] private bool _Put;


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

    private void Start()
    {
        _Put = true;
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        ChangeMoveState();

        if (Vector2.Distance((Vector2)transform.position, (Vector2)playerMoveObject.position) <= _MaxDistanceToMoveObject)
        {
            if (Mathf.Abs(horizontalInput) == 1)
            {
                playerMoveObject.position += new Vector3(horizontalInput * _MoveDistance, 0, 0);
            }
            else if (Mathf.Abs(verticalInput) == 1)
            {
                playerMoveObject.position += new Vector3(0, verticalInput * _MoveDistance, 0);
            }
        }

        /*
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
        */






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

    private void ChangeMoveState()
    {
        if (Vector2.Distance((Vector2)transform.position, (Vector2)playerMoveObject.position) <= _MaxDistanceToMoveObject)
        {
            _Put = true;
            _Moving = false;
            Debug.Log("Stopped");
        }
        else
        {
            _Put = false;
            _Moving = true;
        }
    }

}
