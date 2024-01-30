using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private float turnAround = 1.0f;

    [SerializeField]
    private bool useDeltaTime;

    // Update is called once per frame
    void Update()
    {
        if (!useDeltaTime)
        {
            // rotate transform by turnAmount
        }
        else
        {
            // rotate transform by turnAmount * Time.deltaTime
        }
    }
}
