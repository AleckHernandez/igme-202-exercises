using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField]
    Agent target;

    protected override Vector3 CalculateSteeringForces()
    {
        if (CircleCollision(target.gameObject))
        {
            teleport(target.gameObject);
        }

        Vector3 seekForce = Seek(target);

        return seekForce;
    }

    private void teleport(GameObject target)
    {
        Vector3 newPosition;
        Vector2 bounds = gameObject.GetComponent<PhysicsObject>().ScreenSize;

        float x = Random.Range(-bounds.x, bounds.x);
        float y = Random.Range(-bounds.y, bounds.y);

        newPosition = new Vector3(x, y, 0);


        target.GetComponent<PhysicsObject>().position = newPosition;
        target.transform.position = newPosition;
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
