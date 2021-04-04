using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject checkerPrefab;
    public Row[] rows;
    private GameObject[,] _chackers = new GameObject[4, 4];

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Vector2Int? pos = getMouseToBoardPos();
            if (_chackers != null && pos != null && _chackers[pos.Value.x, pos.Value.y] == null)
            {
                _chackers[pos.Value.x, pos.Value.y] = Instantiate(checkerPrefab, getField(pos.Value.x, pos.Value.y).transform.position, Quaternion.identity);
                float scale = getField(pos.Value.x, pos.Value.y).script.scale;
                _chackers[pos.Value.x, pos.Value.y].transform.localScale = new Vector3(scale, scale, 1);
            }
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
                    if (hit.collider == getField(x, y).collider)
                    {
                        return new Vector2Int(x, y);
                    }
                }
            }
        }
        return null;
    }

    private Field getField(int x, int y)
    {
        return rows[y].fields[x];
    }
}

[Serializable]
public struct Row
{
    public Field[] fields;
}

[Serializable]
public class Field
{
    public PolygonCollider2D collider;
    public Transform transform;
    public FieldScript script;
}