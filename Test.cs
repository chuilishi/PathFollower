using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(HandleUtility.DistancePointToLine(new Vector2(1,1),new Vector2(2,2),(Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}
