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
        public GameObject treePrefab;
        public Text score;
        long dirtBB;
        long treeBB;
        long playerBB;
        long desertBB;
        private GameObject[] tiles;
        private void Start()
        {
            tiles = new GameObject[64];
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
                        // PrintBB(TileType.Dirt.ToString(), dirtBB);
                    }
                    else if (boardComp.boardComp.tileType == TileType.Desert)
                    {
                        desertBB = SetCellState(desertBB, r, c);
                    }
                    tiles[r * Constants.column + c] = tile;
                }
            }
            Debug.Log(CellCount(dirtBB));
            InvokeRepeating("PlantTree", 1, (0.1f));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    var row = (int)hit.collider.transform.position.z;
                    var column = (int)hit.collider.transform.position.x;
                    if (GetCellState((dirtBB|desertBB) & ~treeBB & ~playerBB, row, column))
                    {

                        var house = Instantiate(housePrefab);
                        house.transform.parent = hit.collider.transform;
                        house.transform.localPosition = Vector3.zero;
                        playerBB = SetCellState(playerBB, row, column);
                        CalculateScore();
                    }

                }
            }
        }

        private long SetCellState(long bitBoard, int row, int col)
        {
            long newBit = 1L << (row * Constants.column + col);
            return bitBoard |= newBit;
        }

        private bool GetCellState(long bitBoard, int row, int col)
        {
            long mask = 1L << (row * Constants.column + col);
            return (bitBoard & mask) != 0;
        }
        private void PlantTree()
        {
            int randomRow = UnityEngine.Random.Range(0, Constants.row);
            int randomColumn = UnityEngine.Random.Range(0, Constants.column);

            if (GetCellState(dirtBB & ~treeBB & ~playerBB, randomRow, randomColumn))
            {
                var parentTransform = tiles[randomRow * Constants.column + randomColumn].transform;
                var treeEntity = Instantiate(treePrefab);
                treeEntity.transform.parent = parentTransform;
                treeEntity.transform.localPosition = Vector3.zero;
                treeBB = SetCellState(treeBB, randomRow, randomColumn);
            }
        }
        int CellCount(long bitBoard)
        {
            int counter = 0;
            while (bitBoard != 0)
            {
                bitBoard &= bitBoard - 1;
                counter++;
            }
            return counter;
        }

        void PrintBB(string name, long BB)
        {
            Debug.Log(name + ": " + Convert.ToString(BB, 2).PadLeft(64, '0'));
        }

        void CalculateScore()
        {
            score.text = "Score: " + ((CellCount(playerBB & dirtBB) * 10) + (CellCount(playerBB & desertBB) * 2));
        }
    }

}
