using System;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] private bool useMouse = true;
    [SerializeField] private bool useJoystick;

    public Vector3 moveDirection;
    public Vector3 aimDirection;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        SetMove();
        if (useMouse) MouseAim();
    }

    void SetMove()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    void MouseAim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = _camera.WorldToScreenPoint(transform.position);
        aimDirection = (mousePos - playerPos).normalized;
    }
}
