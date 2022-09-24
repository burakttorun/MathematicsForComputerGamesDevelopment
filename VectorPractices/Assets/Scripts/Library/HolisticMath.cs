using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Scripts.Library
{
    public static class HolisticMath
    {
        public static Coords GetNormal(Coords vector)
        {
            float length = Magnitude(vector);
            if (length <= 0)
                return new Coords(0, 0, 0);

            return new Coords(vector.x / length,
                vector.y / length,
                vector.z / length);
        }

        public static float Magnitude(Coords point1, Coords point2 = null )
        {
            point2 ??= new Coords(0, 0, 0); 
            float dis = Square(point2.x - point1.x) +
                        Square(point2.y - point1.y) +
                        Square(point2.z - point1.z);
            return Mathf.Sqrt(dis);
        }

        public static float Square(float value)
        {
            return value * value;
        }

        public static float Dot(Coords vector1, Coords vector2)
        {
            float result = vector1.x * vector2.x +
                           vector1.y * vector2.y +
                           vector1.z * vector2.z;
            return result;
        }

        public static float Angle(Coords vector1, Coords vector2, bool returnTypeIsDegree =true )
        {
            float dot = Dot(vector1, vector2);
            float multipleMagnitude = Magnitude(vector1) * Magnitude(vector2);
            float radian= Mathf.Acos(dot / multipleMagnitude);
            
            return returnTypeIsDegree ? radian * 180 / Mathf.PI : radian;
        }

        public static Coords Rotate(Coords vector, float angle , bool clockwise)
        {
            angle = clockwise ? Mathf.PI * 2 - angle : angle;
            
            float xVal = (vector.x * Mathf.Cos(angle)) - (vector.y * Mathf.Sin(angle));
            float yVal = (vector.x * Mathf.Sin(angle)) + (vector.y * Mathf.Cos(angle));
            return new Coords(xVal, yVal,0);
        }

        public static Coords Cross(Coords vector1, Coords vector2)
        {
            Coords result = new Coords(
                vector1.y * vector2.z - vector1.z * vector2.y,
                vector1.z * vector2.x - vector1.x * vector2.z,
                vector1.x * vector2.y - vector1.y * vector2.x);
            return result;
        }
    }
}