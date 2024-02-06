using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector3 direction = Vector3.zero;

    public Vector3 Direction
    {
        get { return direction; }
        set
        {
            direction = value.normalized;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector3 v2 = context.ReadValue<Vector2>();
        if (context.performed)
        {
            direction = v2;
        }
        if (context.canceled)
        {
            direction = Vector3.zero;
        }

        
    }
}
