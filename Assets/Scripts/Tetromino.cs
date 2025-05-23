using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Tilemaps;



public enum Tetromino
{
    Letter_I,
    Letter_O,
    Letter_T,
    Letter_J,
    Letter_L,
    Letter_S,
    Letter_Z
}

[Serializable]
public struct TetrominoData
{
    public Tetromino tetromino;

    public Tile tile;
    public Vector2Int[] Cells { get; private set; }


    public void Initialize()
    {
        Cells = Data.Cells[tetromino];
    }
}

