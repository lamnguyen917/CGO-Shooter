using System;
using UnityEngine;

[RequireComponent(typeof(InputControl))]
[RequireComponent(typeof(WeaponControl))]
public class PlayerControl : BaseCharacter
{
    [SerializeField] private InputControl inputControl;
    [SerializeField] private WeaponControl weaponControl;

    [SerializeField] Animator animator;
    [SerializeField] private bool isStableAim;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Vertical = Animator.StringToHash("MoveV");
    private static readonly int Horizontal = Animator.StringToHash("MoveH");

    private void Start()
    {
        onHpUpdate.RemoveAllListeners();
        onHpUpdate.AddListener(UIManager.Instance.UpdateHealBar);
    }

    private void Update()
    {
        RotateDirection(inputControl.aimDirection);
        CheckMovement();
        CheckInput();
    }

    void RotateDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    void CheckMovement()
    {
        animator.SetBool(IsMoving, inputControl.isMoving);
        animator.SetFloat(Horizontal, inputControl.moveDirection.x);
        animator.SetFloat(Vertical, inputControl.moveDirection.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            Debug.Log("Pick up gun " + other.gameObject.name);
            weaponControl.Pickup(other.gameObject);
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (isStableAim)
        {
            weaponControl.StableAim(animator);
        }
    }

    void CheckInput()
    {
        if (inputControl.shoot)
        {
            weaponControl.Fire();
        }

        if (inputControl.pauseButton == ButtonState.IsDown)
        {
            UIManager.Instance.Pause();
        }
    }

    protected override void Dead()
    {
        base.Dead();
        Debug.Log("Player death");
        GameManager.Instance.onPlayerDeath.Invoke();
    }
}
