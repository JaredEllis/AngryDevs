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
    public Dev _dev;

    // public bool touchInput;
    // public bool IsTapPressed { get; private set; } = false;
    public bool win { get; private set; } = false;
    public bool lose { get; private set; } = false;

    public Vector2 touchPosition;
    public bool isPressed;
    public bool isReleased;

    private void Awake()
    {
        _dev = FindObjectOfType<Dev>();
    }

    private void OnEnable()
    {
        if (_touchAction == null)
        {
            _touchAction = new TouchAction();

            _touchAction.Touch.TouchPress.performed += i => isPressed = true;
            _touchAction.Touch.TouchPress.canceled += i => isPressed = false;
            _touchAction.Touch.TouchPress.performed += i => isReleased = false;
            _touchAction.Touch.TouchPress.canceled += i => isReleased = true;

            _touchAction.Touch.TouchPosition.performed += i => touchPosition = i.ReadValue<Vector2>();
            // _touchAction.Touch.TouchPosition.canceled += i => lose = false;
        }
        
        _touchAction.Enable();
    }

    private void OnDisable()
    {
        _touchAction.Disable();
    }

    public void CheckOnDevPressed()
    {
        if (isPressed)
        {
            OnDevPressDown();
            _dev.rb.position = Camera.main.ScreenToWorldPoint(touchPosition);
        }
        if (isReleased)
        {
            OnDevPressUp();
        }
    }

    private void OnDevPressDown()
    {
        _dev.isPressed = true;
        _dev.rb.isKinematic = true;
    }

    private void OnDevPressUp()
    {
        _dev.isPressed = false;
        _dev.rb.isKinematic = false;
        StartCoroutine(_dev.Release());
    }
}
