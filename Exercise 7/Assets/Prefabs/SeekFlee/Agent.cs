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


    protected bool CircleCollision(GameObject target)
    {
        Vector3 dVec = gameObject.transform.position - target.transform.position; // distance vector
        float dist = dVec.magnitude; // magnitude of distance vector
        return dist < (target.GetComponent<PhysicsObject>().radius + gameObject.GetComponent<PhysicsObject>().radius);
    }

}
