using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField]
    Agent target;

    protected override Vector3 CalculateSteeringForces()
    {
        Vector3 seekForce = Seek(target);
        return seekForce;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, physicsObject.Velocity);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Seek(target));

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, -Flee(target));
    }

}
