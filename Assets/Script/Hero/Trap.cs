using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Health _player;

    private void Awake()
    {
        _player = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadTrap"))
        {
            _player.ApplyDamage(100);
        }
    }
}
