using System;
using UnityEngine;

[RequireComponent(typeof(InputControl))]
[RequireComponent(typeof(WeaponControl))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputControl inputControl;
    [SerializeField] private WeaponControl weaponControl;

    [SerializeField] Animator animator;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Vertical = Animator.StringToHash("MoveV");
    private static readonly int Horizontal = Animator.StringToHash("MoveH");

    private void Update()
    {
        RotateDirection(inputControl.aimDirection);
        CheckMovement();
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
}
