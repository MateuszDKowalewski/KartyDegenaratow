using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BoardController : MonoBehaviour
{
    public CheckerFactory checkerFactory;

    public LineDrawer arrowDrawer;
    private Vector2Int _movingFrom;
    private bool _moving;

    private FieldScript _toEnd;
    
    public Row[] rows;
    private GameObject[,] _chackers = new GameObject[4, 4];

    private void Update()
    {
        putChecker();
        showPossibleMoves();
        moveChecker();
        removeChecker();

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector2Int? pos = getMouseToBoardPos();
            if (_chackers != null && pos != null && _chackers[pos.Value.x, pos.Value.y] == null)
            {
                _toEnd = getField(pos.Value.x, pos.Value.y).script;
                _toEnd.StartParticle();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && _toEnd)
        {
            _toEnd.EndParticle();
        }
    }

    private void putChecker()
    {
        var input = Input.inputString;
        Vector2Int? mousePos = getMouseToBoardPos();
        if (mousePos == null || _chackers[mousePos.Value.x, mousePos.Value.y] != null)
        {
            return;
        }
        Vector3 pos = getField(mousePos.Value.x, mousePos.Value.y).transform.position;
        float scale = getField(mousePos.Value.x, mousePos.Value.y).script.scale;
        Vector3 scaleVector = new Vector3(scale, scale, 1); 
        switch(input){
            case "1":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("aplowicz", pos, scaleVector);
                break;
            case "2":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("asexualny", pos, scaleVector);
                break;
            case "3":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("bisexualny", pos, scaleVector);
                break;
            case "4":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("femboy", pos, scaleVector);
                break;
            case "5":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("furry", pos, scaleVector);
                break;
            case "6":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("niebinarny", pos, scaleVector);
                break;
            case "7":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("omnisexualna", pos, scaleVector);
                break;
            case "8":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("otaku", pos, scaleVector);
                break;
            case "9":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("wege", pos, scaleVector);
                break;
            case "0":
                _chackers[mousePos.Value.x, mousePos.Value.y] = checkerFactory.instantiateChecker("yaoistka", pos, scaleVector);
                break;
        }
        
    }

    private void showPossibleMoves()
    {
        Vector2Int? mousePos = getMouseToBoardPos();
        if (mousePos == null || _chackers[mousePos.Value.x, mousePos.Value.y] == null)
        {
            if (!_moving)
            {
                hideAllParticle();
            }
            return;
        }
        CheckerScript checkerScript = _chackers[mousePos.Value.x, mousePos.Value.y].GetComponent(typeof(CheckerScript)) as CheckerScript;
        if (checkerScript is null || _moving)
        {
            return;
        }
        Vector2Int[] possibleMoves = checkerScript.PossibleMoves;
        foreach (var move in possibleMoves)
        {
            Vector2Int targetPos = mousePos.Value + move;
            if (targetPos.x >= 0 && targetPos.x < 4 && targetPos.y >= 0 && targetPos.y < 4 && !_chackers[targetPos.x, targetPos.y])
            {
                getField(targetPos.x, targetPos.y).script.StartParticle();
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
            _moving = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && _moving)
        {
            hideAllParticle();
            arrowDrawer.stopDraw();
            _moving = false;
            if (mousePos != null && _chackers[mousePos.Value.x, mousePos.Value.y] == null && isMoveAvaiable(_movingFrom, mousePos.Value))
            {
                GameObject current = _chackers[_movingFrom.x, _movingFrom.y];
                _chackers[_movingFrom.x, _movingFrom.y] = null;
                _chackers[mousePos.Value.x, mousePos.Value.y] = current;
                float scale = getField(mousePos.Value.x, mousePos.Value.y).script.scale;
                current.transform.position = getField(mousePos.Value.x, mousePos.Value.y).transform.position;
                current.transform.localScale = new Vector3(scale, scale, 1);
            }
        }
    }

    private void removeChecker()
    {
        if (Input.GetKeyUp(KeyCode.Q))
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

    private void hideAllParticle()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                getField(x, y).script.EndParticle();
            }
        }
    }

    private Field getField(int x, int y)
    {
        return rows[y].fields[x];
    }

    private bool isMoveAvaiable(Vector2Int from, Vector2Int to)
    {
        Vector2Int move = to - from;
        CheckerScript script = _chackers[from.x, from.y].GetComponent(typeof(CheckerScript)) as CheckerScript;
        if (!script)
        {
            return false;
        }

        foreach (var possibleMove in script.PossibleMoves)
        {
            if (possibleMove.Equals(move))
            {
                return true;
            }
        }
        return false;
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