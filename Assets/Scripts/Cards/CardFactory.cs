using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    
    private int y;
    private int x;

    void Start()
    {
        y = 10;
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Wypisujemy X: " + x);
    }
}
