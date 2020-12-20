using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrypt : MonoBehaviour
{
    // Start is called before the first frame update

    private int x;
    void Start()
    {
        x = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(x);
    }
}
