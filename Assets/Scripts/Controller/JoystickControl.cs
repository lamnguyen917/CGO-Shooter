using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public static JoystickControl Instance;

    public Vector3 AimDirection;
    public Vector3 MoveDirection;

    [SerializeField] private Joystick leftJoystick;
    [SerializeField] private Joystick rightJoystick;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        MoveDirection = new Vector3(leftJoystick.Horizontal, 0, leftJoystick.Vertical).normalized;
        AimDirection = new Vector3(rightJoystick.Horizontal, 0, rightJoystick.Vertical).normalized;
    }
}
