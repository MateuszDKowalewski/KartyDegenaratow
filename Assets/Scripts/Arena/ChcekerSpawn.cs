using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChcekerSpawn : MonoBehaviour
{
    public GameObject checkerPrefab;

    public void spawn(Transform spawnPoint) {
        Instantiate(checkerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
