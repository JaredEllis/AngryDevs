using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;


    public WinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    
    public override void Enter()
    {
        base.Enter();
        
        Debug.Log("STATE: Win");
        _controller.WinText.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
