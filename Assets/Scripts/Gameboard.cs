using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gameboard : MonoBehaviour
{
    [SerializeField] private TetrominoData[] tetrominos;
    [SerializeField] private Vector3Int position;


    private Block activeBlock;
    private Tilemap tilemap;

    private void Awake()
    {
        activeBlock = GetComponent<Block>();
        tilemap = GetComponentInChildren<Tilemap>();

        for (int i = 0; i < tetrominos.Length; i++)
        {
            tetrominos[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();   
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, tetrominos.Length);
        TetrominoData tData = tetrominos[random];

        activeBlock.Initilize(this, position, tData);
        Set(activeBlock);
    }

    public void Set(Block block)
    {
        for (int i = 0; i < block.Cells.Length; i++)
        {
            Vector3Int tilePosition = block.Cells[i] + block.Position;
            tilemap.SetTile(tilePosition, block.TData.tile);
        }
        
    }
}
