using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    public GameObject map;

    public ChcekerSpawn checkerSpawner;

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
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            Debug.Log(hit.collider.gameObject);
            Debug.Log(hit.collider.gameObject.GetComponent<TileScript>().canPlayerPut());
            Debug.Log(!hit.collider.gameObject.GetComponent<TileScript>().isTaken());
            if (hit &&
                hit.collider.gameObject.transform.parent == map.transform &&
                hit.collider.gameObject.GetComponent<TileScript>().canPlayerPut() &&
                !hit.collider.gameObject.GetComponent<TileScript>().isTaken())
            {
                if(hit.collider.gameObject.transform.parent == map.transform)
                {
                    checkerSpawner.spawn(hit.collider.gameObject.transform, hit.collider.gameObject.GetComponent<TileScript>());
                }
            }
        }
    }
}
