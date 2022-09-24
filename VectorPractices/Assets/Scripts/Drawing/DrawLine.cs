using System;
using System.Collections;
using System.Collections.Generic;
using TheGame.Scripts.Library;
using UnityEngine;

namespace TheGame.Scripts.Drawing
{
    public class DrawLine : MonoBehaviour
    {
        private Coords[] leoPoints =
        {
            new Coords(0, 20),
            new Coords(20, 30),
            new Coords(80, 30), 
            new Coords(30, 50),
            new Coords(80, 50),
            new Coords(70, 60), 
            new Coords(70, 80),
            new Coords(80, 90),
            new Coords(95, 80),
        };
        private void Start()
        {
            for (int i = 0; i < leoPoints.Length; i++)
            {
                Coords.DrawPoint(leoPoints[i],1,Color.red);
            }
            for (int i = 0; i < leoPoints.Length-1; i++)
            {
                Coords.DrawLine(leoPoints[i],leoPoints[i+1],1,Color.cyan);
            }
        }
    }
}