using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction, velocity, acceleration;
    [SerializeField]
    private float mass, muk, maxSpeed;

    public float gravStrength;

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
        ApplyForce(gravity * mass);
    }

    public void LookRotation()
    {

        Vector3 target = direction;
        Vector3 rotateToTarget = Quaternion.Euler(0, 0, 90) * target;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotateToTarget);

        transform.rotation = rotation = Quaternion.RotateTowards(transform.rotation, rotation, 500 * Time.deltaTime);
    }

    public void Bounce()
    {
        if (position.x > max.x)
        {
            velocity.x *= -1/ 1.05f;
            position.x = max.x;

        }
        else if (position.x < min.x)
        {
            velocity.x *= -1/ 1.05f;
            position.x = min.x;
        }

        if (position.y > max.y)
        {
            velocity.y *= -1/ 1.05f;
            position.y = max.y;
        }
        else if (position.y < min.y)
        {
            velocity.y *= -1/ 1.05f;
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

        if (velocity.sqrMagnitude > (MathF.Pow(maxSpeed, 2)))
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        position += velocity * Time.deltaTime;

        LookRotation();
        direction = velocity.normalized;

        
        Bounce();

        transform.position = position;

        

        acceleration = Vector3.zero;


        
    }
}
