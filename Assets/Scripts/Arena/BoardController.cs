using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Row[] rows;
    private GameObject[,] _chackers = new GameObject[4, 4];

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log(getMouseToBoardPos());
        }
    }

    private Nullable<Vector2Int> getMouseToBoardPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
        if(hit.collider != null)
        {
            for (var y = 0; y < 4; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    if (hit.collider == rows[y].fields[x].collider)
                    {
                        return new Vector2Int(x, y);
                    }
                }
            }
        }
        return null;
    }
}

[System.Serializable]
public struct Row
{
    public Field[] fields;
}

[System.Serializable]
public class Field
{
    public PolygonCollider2D collider;
    public Transform transform;
    public FieldScript script;
}