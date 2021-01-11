using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChcekerSpawn : MonoBehaviour
{
    public GameObject checkerPrefab;

    public void spawn(Transform spawnPoint) {
        Instantiate(checkerPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, checkerPrefab.transform.position.z), spawnPoint.rotation);
    }
}
