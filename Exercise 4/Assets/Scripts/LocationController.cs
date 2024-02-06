using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{

    // Assume game window size can not be changed
    [SerializeField] 
    private float boundsX, boundsY;
    private void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        if (x > boundsX || x < -boundsX)
        {
            transform.position = new Vector3(-x, y, 0);
        }
        if (y > boundsY || y < -boundsY)
        {
            transform.position = new Vector3(x, -y, 0);
        }
    }
}
