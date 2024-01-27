using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject creaturePrefab;

    [SerializeField]
    private Vector3 spawnPoint1;
    [SerializeField]
    private Vector3 spawnPoint2;
    [SerializeField]
    private Vector3 spawnPoint3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(creaturePrefab, spawnPoint1, Quaternion.identity);
        Instantiate(creaturePrefab, spawnPoint2, Quaternion.identity);
        Instantiate(creaturePrefab, spawnPoint3, Quaternion.identity);
    }
}
