using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private float turnAround = -6;

    [SerializeField]
    private bool useDeltaTime;

    // Update is called once per frame
    void Update()
    {
        if (!useDeltaTime)
        {
            // rotate transform by turnAmount
            transform.Rotate(new Vector3(0, 0, turnAround));
        }
        else
        {
            // rotate transform by turnAmount * Time.deltaTime
            transform.Rotate(new Vector3(0, 0, turnAround) * Time.deltaTime);
        }
    }
}
