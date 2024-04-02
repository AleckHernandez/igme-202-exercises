using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime, wanderRadius;

    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius);

        return wanderForce;
    }



    
}
