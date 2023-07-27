using System;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    [SerializeField] private InputMode mode;

    public Vector3 moveDirection;
    public Vector3 aimDirection;
    public bool isShooting;
    public bool isMoving;

    private Camera _camera;
    private JoystickControl _joystick;

    private void Start()
    {
        _camera = Camera.main;
        _joystick = JoystickControl.Instance;
    }

    private void Update()
    {
        SetMove();
        SetAim();
    }

    void SetMove()
    {
        switch (mode)
        {
            case InputMode.Keyboard:
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
                isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
                break;
            case InputMode.VirtualJoystick:
                moveDirection = _joystick.MoveDirection;
                break;
            default:
                Debug.LogError("No Input Selected");
                break;
        }
    }

    void SetAim()
    {
        switch (mode)
        {
            case InputMode.Keyboard:
                MouseAim();
                break;
            case InputMode.VirtualJoystick:
                JoystickAim();
                break;
            default:
                Debug.LogError("No Input Selected");
                break;
        }
    }

    void MouseAim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = _camera.WorldToScreenPoint(transform.position);
        aimDirection = (mousePos - playerPos).normalized;
    }

    void JoystickAim()
    {
        aimDirection = _joystick.AimDirection;
    }
}
