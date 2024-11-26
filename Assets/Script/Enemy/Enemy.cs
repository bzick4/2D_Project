using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _enemyAnimation;
    private Health _health;
    private HealBottleManager _healBottle;
    
    
    private void Awake()
    {
        _enemyAnimation = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();
        _healBottle = GetComponentInParent<HealBottleManager>();
    }

    private void OnEnable()
    { 
        if (_health != null) 
        { 
            Health.OnDamage += Dead;
        } 
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            Health.OnDamage -= Dead;
        }
    }
    
    private void Dead()
    {
        if (_health._currentHealth <=0)
        {
            _enemyAnimation.SetTrigger("Dead");
            _healBottle.AddBonus(1);
            Destroy(gameObject, 1f);
        } 
    }
    
}

