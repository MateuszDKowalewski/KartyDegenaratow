﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    public bool firstRow;
    private bool taken;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool canPlayerPut() {
        return firstRow;
    }

    public bool isTaken() {
        return taken;
    }

    public void setTaken(bool taken) {
        this.taken = taken;
    }
}
