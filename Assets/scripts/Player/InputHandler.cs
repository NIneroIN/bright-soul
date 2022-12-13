using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class InputHandler : MonoBehaviour
{
    public static Action<Vector2> DirectionButtonPressed;
    public static Action SpaceButtonPressed;

    private readonly HashSet<KeyCode> buttons = new HashSet<KeyCode>()
    {
        KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceButtonPressed?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        foreach (KeyCode button in buttons)
        {
            if (Input.GetKey(button))
            {
                Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                DirectionButtonPressed?.Invoke(dir);
            }
        }
    }
}
