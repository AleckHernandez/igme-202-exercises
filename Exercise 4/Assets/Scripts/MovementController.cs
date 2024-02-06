using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private InputController controller;

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = controller.Direction;
        transform.position += v3 * speed * Time.deltaTime;
        if (v3 != Vector3.zero)
        {
            transform.up = v3;
        }
    }
}
