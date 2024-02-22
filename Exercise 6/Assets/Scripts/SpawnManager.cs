using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimalTypes
{
    Elephant, 
    Turtle,
    Snail,
    Octopus,
    Kangaroo
}


public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField]
    private List<Sprite> sprites;

    public SpriteRenderer animalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
