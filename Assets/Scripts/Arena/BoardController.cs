using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject checkerPrefab;

    public LineDrawer arrowDrawer;
    private Vector2Int _movingFrom;
    private bool moving = false;
    
    public Row[] rows;
    private GameObject[,] _chackers = new GameObject[4, 4];

    private void Update()
    {
        putChecker();
        moveChecker();
        removeChecker();
    }

    private void putChecker()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Vector2Int? pos = getMouseToBoardPos();
            if (_chackers != null && pos != null && _chackers[pos.Value.x, pos.Value.y] == null)
            {
                float scale = getField(pos.Value.x, pos.Value.y).script.scale;
                _chackers[pos.Value.x, pos.Value.y] = Instantiate(checkerPrefab, getField(pos.Value.x, pos.Value.y).transform.position, Quaternion.identity);
                _chackers[pos.Value.x, pos.Value.y].transform.localScale = new Vector3(scale, scale, 1);
            }
        }
    }

    private void moveChecker()
    {
        Vector2Int? mousePos = getMouseToBoardPos();
        if (Input.GetKeyDown(KeyCode.Mouse0) && mousePos != null && _chackers[mousePos.Value.x, mousePos.Value.y] != null)
        {
            _movingFrom = mousePos.Value;
            arrowDrawer.startDraw(_chackers[mousePos.Value.x, mousePos.Value.y].transform.position);
            moving = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0) && moving)
        {
            arrowDrawer.stopDraw();
            if (mousePos != null && _chackers[mousePos.Value.x, mousePos.Value.y] == null)
            {
                GameObject current = _chackers[_movingFrom.x, _movingFrom.y];
                _chackers[_movingFrom.x, _movingFrom.y] = null;
                _chackers[mousePos.Value.x, mousePos.Value.y] = current;
                float scale = getField(mousePos.Value.x, mousePos.Value.y).script.scale;
                current.transform.position = getField(mousePos.Value.x, mousePos.Value.y).transform.position;
                current.transform.localScale = new Vector3(scale, scale, 1);
                moving = false;
            }
        }
    }

    private void removeChecker()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            Vector2Int? pos = getMouseToBoardPos();
            if (_chackers != null && pos != null && _chackers[pos.Value.x, pos.Value.y] != null)
            {
                Destroy(_chackers[pos.Value.x, pos.Value.y]);
                _chackers[pos.Value.x, pos.Value.y] = null;
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