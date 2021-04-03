using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerScript : Component
{
    private FieldScript _fieldUnder = null;

    public FieldScript getTileUnder() {
        return _fieldUnder;
    }

    public void setTileUnder(FieldScript fieldUnder) {
        _fieldUnder = fieldUnder;
        // tileUnder.setTaken(true);
    }
}
