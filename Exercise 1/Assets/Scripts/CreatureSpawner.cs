using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject creaturePrefab;
    [SerializeField]
    private Vector3 spawnLocationOne;
    [SerializeField]
    private Vector3 spawnLocationTwo;
    [SerializeField]
    private Vector3 spawnLocationThree;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(creaturePrefab, spawnLocationOne, Quaternion.identity);
        Instantiate(creaturePrefab, spawnLocationTwo, Quaternion.identity);
        Instantiate(creaturePrefab, spawnLocationThree, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
