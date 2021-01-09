using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    public GameObject map;
    public List<Transform> tiles;

    void Start()
    {
        tiles = new List<Transform>();
        int childrenAmount = map.transform.childCount;
        for (int i = 0; i < childrenAmount; i++)
        {
            tiles.Add(map.transform.GetChild(i));
        }
        
    }

    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
