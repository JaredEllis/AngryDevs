using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TouchManager : MonoBehaviour
{
    private TouchAction _touchAction;

    // public bool touchInput;
    public bool IsTapPressed { get; private set; } = false;

    private void OnEnable()
    {
        if (_touchAction == null)
        {
            _touchAction = new TouchAction();

            _touchAction.Touch.TouchPress.performed += i => IsTapPressed = true;
            _touchAction.Touch.TouchPress.canceled += i => IsTapPressed = false;
        }
        
        _touchAction.Enable();
    }

    private void OnDisable()
    {
        _touchAction.Disable();
    }
}
