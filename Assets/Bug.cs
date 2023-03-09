using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Bug : MonoBehaviour
{
    private GameFSM _stateMachine;

    public float health = 4f;

    public static int EnemiesAlive = 0;

    public AudioSource deathSound;

    private void Awake()
    {
        _stateMachine = FindObjectOfType<GameFSM>();
    }

    private void Start()
    {
        EnemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > health)
        {
            deathSound.pitch = Random.Range(0.8f,1.2f);
            deathSound.Play();
            Die();
        }
    }

    private void Die()
    {
        EnemiesAlive--;
        if (EnemiesAlive <= 0)
        {
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        Destroy(gameObject);
    }
}
