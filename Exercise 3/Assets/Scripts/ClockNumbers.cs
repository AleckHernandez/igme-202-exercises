using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField]
    private TextMesh tm;
    [SerializeField]
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 12; i++)
        {
            // 12:00 = 3pi/6, 1:00 = 2pi/6, 2:00 = 1pi/6, 3:00 = 12pi/6
           
            float x = radius * Mathf.Cos((i + 2) * Mathf.PI / 6);
            float y = radius * Mathf.Sin((i + 2) * Mathf.PI / 6);

            TextMesh newTm = Instantiate(tm, new Vector3(x, y, 0), Quaternion.identity);

            newTm.text = (13 - i).ToString();
        }
    }
}
