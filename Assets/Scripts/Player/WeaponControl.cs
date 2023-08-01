using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Transform weaponR;

    [SerializeField] private List<Gun> gunList;

    [SerializeField] private Transform aimTransform;

    private int _currentIndex = 0;

    private Gun CurrentGun => gunList[_currentIndex];

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            NextWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            PreviousWeapon();
        }
    }

    public void NextWeapon()
    {
        _currentIndex++;
        if (_currentIndex >= gunList.Count)
        {
            _currentIndex = 0;
        }

        SelectIndexGun();
    }

    public void PreviousWeapon()
    {
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = gunList.Count - 1;
        }

        SelectIndexGun();
    }

    void SelectIndexGun()
    {
        for (int i = 0; i < gunList.Count; i++)
        {
            gunList[i].gameObject.SetActive(i == _currentIndex);
        }
    }

    public void Pickup(GameObject gunObject)
    {
        Gun gun = gunObject.GetComponent<Gun>();
        gun.trigger.enabled = false;
        gunList.Add(gun);

        gunObject.transform.SetParent(weaponR);
        gunObject.transform.localPosition = Vector3.zero;
        gunObject.transform.localRotation = Quaternion.identity;
        gunObject.transform.localScale = Vector3.one;

        _currentIndex = gunList.Count - 1;
        SelectIndexGun();
    }

    public void AimAtTarget(Transform bone, Vector3 targetPosition)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        bone.rotation = aimTowards * bone.rotation;
    }

    public void StableAim(Animator animator)
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, CurrentGun.leftHandIk.position);
        animator.SetIKPosition(AvatarIKGoal.RightHand, CurrentGun.rightHandIk.position);
        var currentGunTransform = CurrentGun.transform;
        currentGunTransform.position = aimTransform.position;
        currentGunTransform.rotation = aimTransform.rotation;
    }

    public void Fire()
    {
        CurrentGun.Shoot();
    }
}
