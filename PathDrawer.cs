using System;
using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using UnityEditor;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public GameObject circle;
    public List<Vector2> points = new();
    private bool _canDraw = true;
    private bool isDrawing = false;
    private bool CanDraw
    {
        get => _canDraw;
        set
        {
            if (!value)
            {
                StartCoroutine(candraw());
            }
            else
            {
                StopAllCoroutines();
            }
            _canDraw = value;
        }
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanDraw)
            {
                points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                CanDraw = false;
            }
        }
    }
    [Button]
    public void CreateLineSo()
    {
        var lineso = ScriptableObject.CreateInstance<LineSO>();
        lineso.lines = points;
        AssetDatabase.CreateAsset(lineso,"Assets/Lines"+"/Line.asset");
    }

    IEnumerator candraw()
    {
        yield return new WaitForSeconds(0.1f);
        _canDraw = true;
    }
}