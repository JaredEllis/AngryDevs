using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Cache = UnityEngine.Cache;

public class Unit : MonoBehaviour
{
    private bool _isDragging, _canDrag;
    private Camera _main;
    private Rigidbody _rigidbody;
    private SpringJoint _springJoint;

    private void Start()
    {
        _main = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _springJoint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        DetectTouch();
    }

    private void DetectTouch()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (_isDragging)
            {
                LaunchPlayer();
            }

            _isDragging = false;
            return;
        }

        if (_canDrag)
        {
            _isDragging = true;
            _rigidbody.isKinematic = true;

            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = _main.ScreenToWorldPoint(touchPosition);
            worldPosition.z = transform.position.z;

            transform.position = worldPosition;
        }
    }

    private void LaunchPlayer()
    {
        _rigidbody.isKinematic = false;
        _canDrag = false;
    }
}
