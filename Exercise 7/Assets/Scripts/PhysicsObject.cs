using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 position, direction, velocity, acceleration;
    [SerializeField]
    private float mass, muk, gravStrength, maxSpeed;

    [SerializeField]
    private bool friction, gravity;


    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    public void ApplyFriction()
    {
        Vector3 friction = (velocity * -1).normalized;

        friction *= muk;
        ApplyForce(friction);
    }

    public void ApplyGravity() 
    {
        Vector3 gravity = new Vector3(0, -gravStrength, 0);
        ApplyForce(gravity * mass);
    }

    public void LookRotation()
    {
        Quaternion rotation = Quaternion.LookRotation((velocity - position), Vector3.up);
        transform.rotation = rotation;
    }

    public void Bounce()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
