using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Transform weaponR;

    [SerializeField] private List<Gun> gunList;

    private int _currentIndex = 0;

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

    public void SelectWeapon(Gun gun)
    {
        foreach (var gun1 in gunList)
        {
            gun.gameObject.SetActive(gun == gun1);
        }

    }
}
