using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheGame.Scripts.Board
{

    public enum TileType
    {
        BigHouse,
        Desert,
        Dirt,
        Grain,
        Pasture,
        Rock,
        Water,
        Woods
    }

    [Serializable]
    public struct BoardComp
    {
        public TileType tileType;
    }
    public class BoardSerialized : MonoBehaviour
    {
        public BoardComp boardComp;
    }

}