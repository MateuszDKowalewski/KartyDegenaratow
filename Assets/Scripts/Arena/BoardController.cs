using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Row[] rows;



    
      
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
