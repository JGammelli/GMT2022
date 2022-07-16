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
    public bool _Moving;
    public bool _Put;


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
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void UpdateCurrentTile()
    {
        /*
        if (_Put)
        {
            Physics2D.OverlapBoxAll(new Vector2(), )
        }



        currentTile = tile;
        currentTileNr = currentTile.tileNr;
        currentTileW = currentTile.tileW;
        currentTileH = currentTile.tileH;
        */
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerMoveObject.position, _MoveSpeed * Time.fixedDeltaTime);
    }

    private void ChangeMoveState()
    {
        if (Vector2.Distance((Vector2)transform.position, (Vector2)playerMoveObject.position) <= _MaxDistanceToMoveObject + 0.1f)
        {
            _Put = true;
            _Moving = false;
        }
        else
        {
            _Put = false;
            _Moving = true;
        }
    }

}
