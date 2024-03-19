using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> monsterPrefabs;

    private List<GameObject> monsters = new List<GameObject>();

    private static Vector3 min, max;


    public void CreateMonster()
    {
        int i = Random.Range(0,monsterPrefabs.Count);

        GameObject monster = Instantiate(monsterPrefabs[i], RandomVector3(), Quaternion.identity);
        monsters.Add(monster);
    }

    public void RemoveMonster()
    {
        if (monsters.Count > 0)
        {
            Destroy(monsters[0]);
            monsters.RemoveAt(0);
        }
    }
    public void ClearMonsters()
    {
        foreach (GameObject monster in monsters)
        {
            Destroy(monster);
        }
        monsters.Clear();
    }

    public Vector3 RandomVector3()
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        return new Vector3(x, y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        
    }

    public static Vector3 Min { get { return min; } }
    public static Vector3 Max { get { return max; } }

    // Update is called once per frame
    void Update()
    {
        
    }
}
