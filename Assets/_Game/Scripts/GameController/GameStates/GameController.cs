using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 0.2f;
    
    [Header("Dependencies")]
    [SerializeField] private Dev _devPrefab;
    [SerializeField] private Transform _playerUnitSpawnLocation;
    [SerializeField] private UnitSpawner _unitSpawner;
    // [SerializeField] private InputBroadcaster _input;
    [SerializeField] private TouchManager _touchManager;

    public float TapLimitDuration => _tapLimitDuration;
    public Dev DevPrefab => _devPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    // public InputBroadcaster Input => _input;
    public TouchManager TouchManager => _touchManager;

    
}
