using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    public GameObject circle;
    public float maxDistance = 1.0f;
    //当前所在的Line的Index
    // public int curLineIndex;
    private List<Line> lines = new List<Line>();
    public List<Vector2> points;
    public LineSO lineso;
    private void Start()
    {
        points = lineso.lines;
        for (int i = 0; i < points.Count-1; i++)
        {
            lines.Add(new Line(points[i],points[i+1]));
            // Instantiate(circle, points[i], Quaternion.identity);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(transform.position, mousePos) < maxDistance)
            {
                float minDistance = float.MaxValue;
                Vector2 footPoint = Vector2.zero;
                bool canMove = false;
                for(int i=0;i<lines.Count;i++)
                {
                    if (Line.DistancePointToLine(transform.position, lines[i])<minDistance)
                    {
                        if (Line.FootPointOfPointToLine(mousePos, lines[i], out Vector2 fp))
                        {
                            footPoint = fp;
                            minDistance = Line.DistancePointToLine(transform.position, lines[i]);
                            canMove = true;
                        }
                    }
                }

                if (canMove)
                {
                    if (!(Vector2.Distance(transform.position, footPoint) > 1f))
                    {
                        transform.position = footPoint;
                    }
                    
                }
            }
        }
    }
}
