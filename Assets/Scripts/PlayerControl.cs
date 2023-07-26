using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputControl))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputControl inputControl;

    private void Update()
    {
        RotateDirection(inputControl.aimDirection);
    }

    void RotateDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}
