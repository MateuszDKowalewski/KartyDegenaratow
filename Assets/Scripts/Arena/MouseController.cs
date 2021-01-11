using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    
    public GameObject map;

    public ChcekerSpawn checkerSpawner;

    public List<Transform> tiles;

    public LineDrawer lineDrawer;
    private GameObject selectedChackers = null;

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
        this.tryPlaceChecker();
        this.tryMoveChecker();
    }

    private void tryPlaceChecker()
    {
        if(Input.GetMouseButtonUp(0) && this.selectedChackers == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            if (hit &&
                hit.collider.gameObject.transform.parent == map.transform &&
                hit.collider.gameObject.GetComponent<TileScript>() != null &&
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

    private void tryMoveChecker()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            if (hit && hit.collider.gameObject.GetComponent<CheckerScript>() != null)
            {
                this.selectedChackers = hit.collider.gameObject;
                lineDrawer.setStart(hit.collider.gameObject.transform.position);
                lineDrawer.startDraw();
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineDrawer.reset();
            this.selectedChackers = null;
        }
    }

}
