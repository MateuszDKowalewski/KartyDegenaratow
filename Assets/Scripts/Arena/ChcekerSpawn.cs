using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChcekerSpawn : MonoBehaviour
{
    public GameObject checkerPrefab;

    public void spawn(Transform spawnPoint, TileScript tileUnder) {
        GameObject prefabInstance = Instantiate(checkerPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, checkerPrefab.transform.position.z), spawnPoint.rotation);

        if(prefabInstance != null)
        {
            var myScriptReference = prefabInstance.GetComponent<CheckerScript>();
            if( myScriptReference != null )
            {
                myScriptReference.setTileUnder(tileUnder);
            }
        }

    }
}

