using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TouchManager : MonoBehaviour
{
    private TouchAction _touchAction;
    private Unit _unit;

    // public bool touchInput;
    // public bool IsTapPressed { get; private set; } = false;
    public bool win { get; private set; } = false;
    public bool lose { get; private set; } = false;

    private void OnEnable()
    {
        if (_touchAction == null)
        {
            _touchAction = new TouchAction();

            _touchAction.Touch.TouchPress.performed += i => win = true;
            _touchAction.Touch.TouchPress.canceled += i => win = false;

            _touchAction.Touch.TouchPosition.performed += i => lose = true;
            _touchAction.Touch.TouchPosition.canceled += i => lose = false;
        }
        
        _touchAction.Enable();
    }

    private void OnDisable()
    {
        _touchAction.Disable();
    }
}
