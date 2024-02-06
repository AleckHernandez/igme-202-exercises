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
        Vector3 v3 = controller.direction;
        transform.position += v3 * speed * Time.deltaTime;
    }
}
