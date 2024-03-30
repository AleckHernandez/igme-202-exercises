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

    private Vector2 screenSize = Vector2.zero;


    public float radius;


    public float MaxSpeed { get { return maxSpeed; } }
    public Vector3 Velocity { get { return velocity; } }

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

    /*
    public void LookRotation()
    {

        Vector3 target = direction;
        Vector3 rotateToTarget = Quaternion.Euler(0, 0, 90) * target;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotateToTarget);

        transform.rotation = rotation = Quaternion.RotateTowards(transform.rotation, rotation, 500 * Time.deltaTime);
    }
    */

    public void Bounce()
    {
        if (position.x > screenSize.x || position.x < -screenSize.x)
        {
            velocity.x *= -1f;
        }
        if (position.y > screenSize.y || position.y < -screenSize.y)
        {
            velocity.y *= -1f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<SpriteRenderer>().bounds.extents.y;

        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;
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

        /*if (velocity.sqrMagnitude > (MathF.Pow(maxSpeed, 2)))
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }*/
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);


        position += velocity * Time.deltaTime;
        

        direction = velocity.normalized;

        
        Bounce();



        transform.position = position;


        //LookRotation();
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);



        acceleration = Vector3.zero;


        
    }
}
