using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;

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
