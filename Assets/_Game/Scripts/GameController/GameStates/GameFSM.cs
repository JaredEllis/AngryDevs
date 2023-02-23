using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;
    
    public GameSetupState SetupState { get; private set; }
    public GamePlayState PlayState { get; private set; }
    
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<GameController>();
        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
