using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour
{
    [SerializeField] private InputMode mode;

    public ButtonState pauseButton;
    public Vector3 moveDirection;
    public Vector3 aimDirection;
    public bool shoot;
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
        CheckButtonState();
    }

    void SetMove()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        switch (mode)
        {
            case InputMode.Keyboard:
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
                isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
                shoot = Input.GetButton("Fire1");
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

    void CheckButtonState()
    {
        pauseButton = GetButtonState(KeyCode.Escape);
    }

    ButtonState GetButtonState(KeyCode code)
    {
        if (Input.GetKeyDown(code)) return ButtonState.IsDown;
        if (Input.GetKeyUp(code)) return ButtonState.IsUp;
        if (Input.GetKey(code)) return ButtonState.IsHold;
        return ButtonState.Normal;
    }
}
