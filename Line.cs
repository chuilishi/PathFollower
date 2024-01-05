using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line
{
    private Vector2 v1;
    private Vector2 v2;
    public Line(Vector2 v1,Vector2 v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public static float DistancePointToLine(Vector2 vp,Vector2 v1,Vector2 v2)
    {
        return Mathf.Min(
            HandleUtility.DistancePointToLine(vp, v1, v2),
            Mathf.Min(Vector2.Distance(vp,v1),Vector2.Distance(vp,v2))
            );
    }
    public static float DistancePointToLine(Vector2 vp,Line line)
    {
        var v1 = line.v1;
        var v2 = line.v2;
        return Mathf.Min(
            HandleUtility.DistancePointToLine(vp, v1, v2),
            Mathf.Min(Vector2.Distance(vp,v1),Vector2.Distance(vp,v2))
        );
    }
    public static bool FootPointOfPointToLine(Vector2 point, Vector2 v0, Vector2 v1,out Vector2 footPoint)
    {
        // if (v0.x == v1.x && v0.y == v1.y)
        // {
        //     res = new Vector2(v0.x, v0.y);
        //     return true;
        // }

        float k = -((v0.x - point.x) * (v1.x - v0.x) + (v0.y - point.y) * (v1.y - v0.y)) / ((v0.x - v1.x) * (v0.x - v1.x) + (v0.y - v1.y) * (v0.y - v1.y));
        float xf = k * (v1.x - v0.x) + v0.x;
        float yf = k * (v1.y - v0.y) + v0.y;
        bool flag = k >= 0 && k <= 1;
        footPoint = new Vector2(xf, yf);
        return flag;
    }

    public static bool FootPointOfPointToLine(Vector2 point, Line line, out Vector2 footPoint)
    {
        var v0 = line.v1;
        var v1 = line.v2;
        // if (v0.x == v1.x && v0.y == v1.y)
        // {
        //     res = new Vector2(v0.x, v0.y);
        //     return true;
        // }

        float k = -((v0.x - point.x) * (v1.x - v0.x) + (v0.y - point.y) * (v1.y - v0.y)) / ((v0.x - v1.x) * (v0.x - v1.x) + (v0.y - v1.y) * (v0.y - v1.y));
        float xf = k * (v1.x - v0.x) + v0.x;
        float yf = k * (v1.y - v0.y) + v0.y;
        bool flag = k >= 0 && k <= 1;
        footPoint = new Vector2(xf, yf);
        
        return flag;
    }
}
