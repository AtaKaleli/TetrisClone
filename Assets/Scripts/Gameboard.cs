using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gameboard : MonoBehaviour
{
    [SerializeField] private TetrominoData[] tetrominos;
    [SerializeField] private Vector3Int spawnPosition;


    public Block ActiveBlock { get; private set; }
    public Tilemap Tilemap { get; private set; }


    private void Awake()
    {
        ActiveBlock = GetComponentInChildren<Block>(); //?
        Tilemap = GetComponentInChildren<Tilemap>();

       

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

        ActiveBlock.Initialize(this, spawnPosition, tData);
        Set(ActiveBlock);
        
    }

    public void Set(Block block)
    {
        for (int i = 0; i < block.Cells.Length; i++)
        {
            Vector3Int tilePosition = block.Cells[i] + block.Position;
            Tilemap.SetTile(tilePosition, block.TData.tile);
        }
    }

}
