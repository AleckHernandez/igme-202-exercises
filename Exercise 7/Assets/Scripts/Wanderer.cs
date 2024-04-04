using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime = 1f, wanderRadius = 1f, wanderWeight = 1f, boundsWeight = 1f;

    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius);

        Vector3 boundsForce = StayInBounds();


        return wanderForce + boundsForce;
    }



    
}
