using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChcekerSpawn : MonoBehaviour
{
    public GameObject checkerPrefab;

    // ReSharper disable Unity.PerformanceAnalysis
    public void spawn(Transform spawnPoint, FieldScript fieldUnder)
    {
        var position = spawnPoint.position;
        GameObject prefabInstance = Instantiate(checkerPrefab, new Vector3(position.x, position.y, checkerPrefab.transform.position.z), spawnPoint.rotation);
        if (prefabInstance != null)
        {
            var myScriptReference = prefabInstance.GetComponent<CheckerScript>();
            if (myScriptReference != null)
            {
                myScriptReference.setTileUnder(fieldUnder);
            }
        }
    }
}