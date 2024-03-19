using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction, velocity, acceleration;
    [SerializeField]
    private float mass, muk, gravStrength, maxSpeed;

    [SerializeField]
    private bool friction, gravity;

    public Vector3 position;

    private Vector3 min, max;


    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    public void ApplyFriction()
    {
        Vector3 friction = (direction * -1);

        friction *= muk;
        ApplyForce(friction);
    }

    public void ApplyGravity() 
    {
        Vector3 gravity = new Vector3(0, -gravStrength, 0);
        acceleration += gravity;
        //ApplyForce(gravity * mass);
    }

    public void LookRotation()
    {
        Quaternion rotation = Quaternion.LookRotation((velocity - position), Vector3.up);
        transform.rotation = rotation;
    }

    public void Bounce()
    {
        if (position.x > max.x)
        {
            velocity.x *= -1;
            position.x = max.x;
        }
        else if (position.x < min.x)
        {
            velocity.x *= -1;
            position.x = min.x;
        }

        if (position.y > max.y)
        {
            velocity.y *= -1;
            position.y = max.y;
        }
        else if (position.y < min.y)
        {
            velocity.y *= -1;
            position.y = min.y;
        }
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        min = SceneManager.Min;
        max = SceneManager.Max;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (gravity)
        {
            ApplyGravity();
        }
        if (friction)
        {
            ApplyFriction();
        }

        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;

        direction = velocity.normalized;

        
        Bounce();

        transform.position = position;

        

        acceleration = Vector3.zero;


        
    }
}
