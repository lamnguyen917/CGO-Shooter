using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerDoor : EnemySpawner
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;
    [SerializeField] private Vector3 leftClosePosition;
    [SerializeField] private Vector3 rightClosePosition;
    [SerializeField] private Vector3 lefOpenPosition;
    [SerializeField] private Vector3 rightOpenPosition;


    private bool _isOpen = false;
    private Vector3 _leftDoorTargetPosition;
    private Vector3 _rightDoorTargetPosition;
    
    protected override void ChildStart()
    {
        leftClosePosition = leftDoor.localPosition;
        rightClosePosition = rightDoor.localPosition;
        Close();
    }

    protected override void ChildUpdate()
    {
        
    }

    // private void Update()
    // {
    //     
    //     // if ((leftDoor.localPosition - _leftDoorTargetPosition).magnitude > 0.001f)
    //     // {
    //     //     leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, _leftDoorTargetPosition, Time.deltaTime);
    //     // }
    //     //
    //     // if ((rightDoor.localPosition - _rightDoorTargetPosition).magnitude > 0.001f)
    //     // {
    //     //     rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, _rightDoorTargetPosition, Time.deltaTime);
    //     // }
    //     //
    //     // if (Input.GetKeyDown(KeyCode.T))
    //     // {
    //     //     Toggle();
    //     // }
    // }

    public void Toggle()
    {
        if (_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        if (_isOpen) return;
        _isOpen = true;
        _leftDoorTargetPosition = lefOpenPosition;
        _rightDoorTargetPosition = rightOpenPosition;
    }

    public void Close()
    {
        if (!_isOpen) return;
        _isOpen = false;
        _leftDoorTargetPosition = leftClosePosition;
        _rightDoorTargetPosition = rightClosePosition;
    }
}
