using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject map;
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
        // tryPlaceChecker();
        // tryMoveChecker();
        // tryRemoveChecker();
    }

    private void tryPlaceChecker()
    {
        if(Input.GetMouseButtonUp(0) && this.selectedChackers == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            if (hit &&
                hit.collider.gameObject.transform.parent == map.transform &&
                hit.collider.gameObject.GetComponent<FieldScript>() != null)
                // hit.collider.gameObject.GetComponent<TileScript>().canPlayerPut() &&
                // !hit.collider.gameObject.GetComponent<TileScript>().isTaken())
            {
                // checkerSpawner.spawn(hit.collider.gameObject.transform, hit.collider.gameObject.GetComponent<FieldScript>());
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
            if(this.selectedChackers != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
                if (hit &&
                    hit.collider.gameObject.transform.parent == map.transform &&
                    hit.collider.gameObject.GetComponent<FieldScript>() != null)
                    // !hit.collider.gameObject.GetComponent<TileScript>().isTaken())
                {
                    CheckerScript cs = this.selectedChackers.GetComponent<CheckerScript>();
                    if(cs != null)
                    {
                        // cs.getTileUnder().setTaken(false);
                        // cs.setTileUnder(hit.collider.gameObject.GetComponent<FieldScript>());
                    }
                    this.selectedChackers.transform.position = new Vector3(
                        hit.collider.gameObject.transform.position.x,
                        hit.collider.gameObject.transform.position.y,
                        this.selectedChackers.transform.position.z);
                }
            }
            lineDrawer.reset();
            this.selectedChackers = null;
        }
    }

    private void tryRemoveChecker()
    {
        if(Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
            if (hit && hit.collider.gameObject.GetComponent<CheckerScript>() != null)
            {
                // hit.collider.gameObject.GetComponent<CheckerScript>().getTileUnder().setTaken(false);
                Destroy(hit.collider.gameObject);
            }
        }
    }

}
