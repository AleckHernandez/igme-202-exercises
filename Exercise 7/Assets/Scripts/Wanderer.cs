using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime = 1f, wanderRadius = 1f, wanderDeviation = 5f;

    float prevAngle = 0f;

    protected override Vector3 CalculateSteeringForces()
    {

        wanderDeviation = Random.Range(-10f, 10f) * Mathf.PI / 180;

        Vector3 wanderForce = Wander(wanderTime, wanderRadius, wanderDeviation);

        Vector3 boundsForce = StayInBounds();
        float boundsWeight = boundsForce.sqrMagnitude / 2;


        return wanderForce + (boundsForce * boundsWeight);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Vector3 futurePosition = CalcFuturePosition(wanderTime);
        Gizmos.DrawWireSphere(futurePosition, wanderRadius);

        Gizmos.color = Color.cyan;

        //float randAngle = Random.Range(0f, 2f * Mathf.PI);
        float randAngle = prevAngle + wanderDeviation;

        prevAngle = randAngle;

        Vector3 wanderTarget = futurePosition;

        wanderTarget.x += Mathf.Cos(randAngle) * wanderRadius;
        wanderTarget.y += Mathf.Sin(randAngle) * wanderRadius;

        Gizmos.DrawLine(transform.position, wanderTarget);
    }


}
