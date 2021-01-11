using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScript : MonoBehaviour
{

    private TileScript tileUnder = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setTileUnder(TileScript tileUnder) {
        this.tileUnder = tileUnder;
        tileUnder.setTaken(true);
    }
}
