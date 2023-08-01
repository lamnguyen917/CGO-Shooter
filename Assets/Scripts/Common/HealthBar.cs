using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private BaseCharacter target;
    private Transform _cameraTransform;

    private void Start()
    {
        if (Camera.main) _cameraTransform = Camera.main.transform;
        target.onHpUpdate.AddListener(UpdateHp);
    }

    public void UpdateHp(float hp, float maxHp)
    {
        bar.fillAmount = hp / maxHp;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraTransform.forward);
    }
}
