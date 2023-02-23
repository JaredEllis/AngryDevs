using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 0.2f;
    
    [Header("Dependencies")]
    [SerializeField] private Unit _playerUnitPrefab;
    [SerializeField] private Transform _playerUnitSpawnLocation;
    [SerializeField] private UnitSpawner _unitSpawner;
    // [SerializeField] private InputBroadcaster _input;
    [SerializeField] private TouchManager _touchManager;

    public float TapLimitDuration => _tapLimitDuration;
    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner;
    // public InputBroadcaster Input => _input;
    public TouchManager TouchManager => _touchManager;
}
