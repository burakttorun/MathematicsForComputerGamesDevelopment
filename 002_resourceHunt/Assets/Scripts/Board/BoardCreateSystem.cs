using System;
using TheGame.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace TheGame.Scripts.Board
{

    public class BoardCreateSystem : MonoBehaviour
    {
        public GameObject[] tilePrefabs;
        public GameObject housePrefab;
        public Text score;
        long dirtBB;
        private void Start()
        {
            CreateBoard();
        }
        public void CreateBoard()
        {

            for (int r = 0; r < Constants.row; r++)
            {
                for (int c = 0; c < Constants.column; c++)
                {
                    int randomTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                    Vector3 spawnPosition = new Vector3(c, 0, r);
                    var tile = Instantiate(tilePrefabs[randomTile], spawnPosition, Quaternion.identity);
                    var boardComp = tile.GetComponent<BoardSerialized>();
                    tile.name = boardComp.boardComp.tileType + "_" + r + "_" + c;

                    if (boardComp.boardComp.tileType == TileType.Dirt)
                    {
                        dirtBB = SetCellState(dirtBB, r, c);
                        PrintBB(TileType.Dirt.ToString(), dirtBB);
                    }

                }
            }
        }

        private long SetCellState(long bitBoard, int row, int col)
        {
            long newBit = 1L << (row * Constants.column + col);
            return bitBoard |= newBit;
        }

        void PrintBB(string name, long BB)
        {
            Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
        }
    }

}
