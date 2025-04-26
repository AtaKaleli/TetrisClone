using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Gameboard Board { get; private set; }
    public Vector3Int Position { get; private set; }
    public Vector3Int[] Cells { get; private set; }
    public TetrominoData TData { get; private set; }

    public void Initialize(Gameboard board, Vector3Int position, TetrominoData tData)
    {
        Board = board;
        Position = position;
        TData = tData;

        Cells ??= new Vector3Int[tData.Cells.Length];
        

        for (int i = 0; i < tData.Cells.Length; i++)
        {
            Cells[i] = (Vector3Int)tData.Cells[i];
            
        }
    }
}
