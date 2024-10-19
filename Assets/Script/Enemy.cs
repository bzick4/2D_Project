using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _EnemyAnimation;
    [SerializeField] private Health _Health;
    private void Update()
    {
        if (_Health._currentHealth <=0)
        {
            _EnemyAnimation.SetBool("isDead", true);
        }
    }
}

