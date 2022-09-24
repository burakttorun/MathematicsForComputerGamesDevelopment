using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Scripts.Library
{
    public enum DrawingType
    {
        Point,
        Line
    }
    public class Coords
    {
        public float x;
        public float y;
        public float z;

        public Coords(float xAxis, float yAxis)
        {
            x = xAxis;
            y = yAxis;
            z = 1;
        } 
        public Coords(float xAxis, float yAxis,float zAxis)
        {
            x = xAxis;
            y = yAxis;
            z = zAxis;
        }
        public Coords(Vector3 vecPos)
        {
            x =vecPos.x;
            y =vecPos.y;
            z =vecPos.z;
        }

        public override string ToString()
        {
            return "(" + x + ',' + y + ',' + z + ")";
        }
        
        public Vector3 ToVector()
        {
            return new Vector3(x, y, z);
        }
        /// <summary>
        /// Draw point to given position
        /// </summary>
        public static void DrawPoint(Coords position, float width, Color color)
        {
            DrawLine(
                new Coords(position.x - width / 3, position.y - width / 3),
                new Coords(position.x + width / 3, position.y + width / 3),1,
                color,DrawingType.Point);
        }

        /// <summary>
        /// Draw line between to given point
        /// </summary>
        public static void DrawLine(Coords startPoint, Coords endPoint, float width, Color color,DrawingType drawingType= DrawingType.Line)
        {
            var objectName = drawingType.ToString() + startPoint + "=>" + endPoint;
            GameObject line = new GameObject(objectName);
            var lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0,new Vector3(startPoint.x,startPoint.y,startPoint.z));
            lineRenderer.SetPosition(1,new Vector3(endPoint.x,endPoint.y,endPoint.z));
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }
    }
}