using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimalTypes
{
    Elephant, 
    Kangaroo,
    Octopus,
    Snail,
    Turtle
}


public class SpawnManager : Singleton<SpawnManager>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    [SerializeField]
    private List<Sprite> sprites;

    public SpriteRenderer animalPrefab;

    [SerializeField]
    private int animalCount;

    public List<SpriteRenderer> spawnedAnimals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    public AnimalTypes PickRandomCreature()
    {
        float rand = Random.Range(0f, 1f);
        
        if (rand < .25f)
        {
            return AnimalTypes.Elephant;
        }
        else if (rand < .55f)
        {
            return AnimalTypes.Kangaroo;
        }
        else if (rand < .65f)
        {
            return AnimalTypes.Octopus;
        }
        else if (rand < .8f)
        {
            return AnimalTypes.Snail;
        }
        else
        {
            return AnimalTypes.Turtle;
        }
    }


    public void Spawn()
    {
        CleanUp();
        for(int i = 0; i < animalCount; i++)
        {
            SpawnAnimal();
        }
    }

    public void SpawnAnimal()
    {
        SpriteRenderer newAnimal = Instantiate(animalPrefab);

        // Change sprite
        newAnimal.sprite = sprites[(int) PickRandomCreature()];

        // Change color
        newAnimal.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        // Set position
        float screenH = Camera.main.orthographicSize * 2f;
        float screenW = screenH * Camera.main.aspect;

        float x = Gaussian(0, screenW / 8);
        float y = Gaussian(0, screenH / 8);

        newAnimal.transform.position = new Vector3(x, y, 0);
        

        spawnedAnimals.Add(newAnimal);
    }

    void CleanUp()
    {
        foreach(SpriteRenderer animal in spawnedAnimals)
        {
            Destroy(animal.gameObject);
        }
        spawnedAnimals.Clear();
    }
}
