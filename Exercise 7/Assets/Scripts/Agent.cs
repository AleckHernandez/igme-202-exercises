using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{

    [SerializeField]
    protected PhysicsObject physicsObject;

    [SerializeField]
    private float maxForce = 5f;

    protected Vector3 totalForces = Vector3.zero;

    private float previousAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalForces += CalculateSteeringForces();

        totalForces = Vector3.ClampMagnitude(totalForces, maxForce);

        physicsObject.ApplyForce(totalForces);

        totalForces = Vector3.zero;
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

    public Vector3 Wander(float time, float radius, float deviation)
    {
        Vector3 futurePosition = CalcFuturePosition(time);

        //float randAngle = Random.Range(0f, 2f * Mathf.PI);
        float randAngle = previousAngle + deviation;

        previousAngle = randAngle;

        Vector3 wanderTarget = futurePosition;

        float updateRadius = radius * futurePosition.magnitude;

        wanderTarget.x += Mathf.Cos(randAngle) * radius;
        wanderTarget.y += Mathf.Sin(randAngle) * radius;

        return Seek(wanderTarget);
    }

    public Vector3 StayInBounds()
    {
        Vector3 steeringForce = Vector3.zero;

        Vector3 futurePosition = CalcFuturePosition(.05f); // Calculate future position

        if (CheckIfInBounds(futurePosition))
        {
            // If future position is out of bounds, steer back in bounds
            steeringForce += Seek(Vector3.zero);
        }

        return steeringForce;
    }

    protected bool CheckIfInBounds(Vector3 position)
    {
        if (position.x > AgentManager.Instance.ScreenSize.x ||
            position.x < -AgentManager.Instance.ScreenSize.x ||
            position.y > AgentManager.Instance.ScreenSize.y ||
            position.y < -AgentManager.Instance.ScreenSize.y)
        {
            return true;
        }
        return false;
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
