using System.Collections;
using System.Collections.Generic;
using TheGame.Scripts.Library;
using UnityEngine;

public class DrawGraphLine : MonoBehaviour
{
    public int size = 20;
    public int displayRatioX = 16;
    public int displayRatioY = 10;
    private Coords _xAxisMaxPoint;
    private Coords _xAxisMinPoint;
    private Coords _yAxisMaxPoint;
    private Coords _yAxisMinPoint;

    void Start()
    {
        var yAxisLimit = Camera.main.orthographicSize;
        _yAxisMaxPoint = new Coords(0, yAxisLimit);
        _yAxisMinPoint = new Coords(0, -yAxisLimit);
        _xAxisMaxPoint = new Coords(yAxisLimit / displayRatioY * displayRatioX, 0);
        _xAxisMinPoint = new Coords(-yAxisLimit / displayRatioY * displayRatioX, 0);
        Coords.DrawLine(_yAxisMinPoint, _yAxisMaxPoint, 1, Color.red);
        Coords.DrawLine(_xAxisMinPoint, _xAxisMaxPoint, 1, Color.green);

        int offSetX = (int)(yAxisLimit) / size;
        for (int i = -offSetX * size; i <= offSetX * size; i += size)
        {
            var startPos = new Coords(-yAxisLimit / displayRatioY * displayRatioX, i);
            var endPos = new Coords(yAxisLimit / displayRatioY * displayRatioX, i);
            Coords.DrawLine(startPos, endPos, 1, Color.white);
        }

        int offSetY = (int)(yAxisLimit / displayRatioY * displayRatioX) / size;
        for (int i = -offSetY * size; i <= offSetY * size; i += size)
        {
            var startPos = new Coords(i, -yAxisLimit);
            var endPos = new Coords(i, yAxisLimit);
            Coords.DrawLine(startPos, endPos, 1, Color.white);
        }
    }
}