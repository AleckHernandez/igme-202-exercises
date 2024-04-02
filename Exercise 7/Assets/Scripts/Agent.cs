using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{

    [SerializeField]
    protected PhysicsObject physicsObject;

    [SerializeField]
    protected Vector3 maxForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 steeringForce = CalculateSteeringForces();

        physicsObject.ApplyForce(steeringForce);
    }

    protected abstract Vector3 CalculateSteeringForces();


    public Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - transform.position;

        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;

        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        return seekingForce;
    }
    
    public Vector3 Seek(Agent target)
    {
        return Seek(target.transform.position);
    }

    public Vector3 Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = transform.position - targetPos;
        desiredVelocity = desiredVelocity.normalized * physicsObject.MaxSpeed;
        Vector3 fleeingForce = desiredVelocity - physicsObject.Velocity;
        return fleeingForce;
    }

    public Vector3 Flee(Agent target)
    {
        return Flee(target.transform.position);
    }

    public Vector3 Evade(Agent target)
    {
        return Flee(target.CalcFuturePosition(5f));
    }

    public Vector3 Wander(float time, float radius)
    {
        Vector3 futurePosition = CalcFuturePosition(time);

        float randAngle = Random.Range(0f, 2f * Mathf.PI);

        Vector3 wanderTarget = futurePosition;

        wanderTarget.x += Mathf.Cos(randAngle) * radius;
        wanderTarget.y += Mathf.Sin(randAngle) * radius;

        return Seek(wanderTarget);
    }


    protected bool CircleCollision(GameObject target)
    {
        Vector3 dVec = gameObject.transform.position - target.transform.position; // distance vector
        float dist = dVec.magnitude; // magnitude of distance vector
        return dist < (target.GetComponent<PhysicsObject>().radius + gameObject.GetComponent<PhysicsObject>().radius);
    }


    public Vector3 CalcFuturePosition(float futureTime)
    {
        return transform.position + (physicsObject.Velocity * futureTime);
    }

    

}
