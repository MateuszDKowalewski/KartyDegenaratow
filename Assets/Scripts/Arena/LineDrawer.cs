using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private Vector3 start;
    private Vector3 end;
    private bool draw = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        if(draw)
        {
            Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            end = new Vector3(temp.x, temp.y, 6f);
            lineRenderer.SetPosition(0, this.start);
            lineRenderer.SetPosition(1, this.end);
        }
    }

    public void reset()
    {
        this.start = new Vector3(0f, 0f, 6f);
        this.end = new Vector3(0f, 0f, 6f);
        lineRenderer.SetPosition(0, this.start);
        lineRenderer.SetPosition(1, this.end);
        this.draw = false;
    }

    public void startDraw()
    {
        this.draw = true;
    }

    public void setStart(Vector3 position)
    {
        this.start = position;
        this.start.z = 6;
    }
}
