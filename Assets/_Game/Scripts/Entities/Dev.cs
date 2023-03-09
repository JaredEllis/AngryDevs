using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dev : MonoBehaviour
{
    private GameFSM _stateMachine;
    
    public float releaseTime = 0.15f;
    
    public Rigidbody2D rb;
    
    public bool isPressed = false;
    public GameObject nextDev;
    private GameController _controller;
    public AudioSource releaseSound;

    private void Awake()
    {
        _stateMachine = FindObjectOfType<GameFSM>();
        _controller = FindObjectOfType<GameController>();
    }

    public IEnumerator Release()
    {
        releaseSound.pitch = Random.Range(0.8f,1.2f);
        releaseSound.Play();
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(5f);
        
        if (nextDev != null)
        {
            //nextDev = _controller.UnitSpawner.Spawn(_controller.DevPrefab, GetComponent<SpringJoint2D>().transform);
            nextDev.SetActive(true);
        }
        else
        {
            if (Bug.EnemiesAlive > 0)
                _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}
