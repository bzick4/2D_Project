using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _enemyAnimation;
    private Health _health;

    public static event Action OnGiveHealBottle; 
    
    private void Awake()
    {
        _enemyAnimation = GetComponentInChildren<Animator>();
        _health = GetComponent<Health>();
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
            OnGiveHealBottle?.Invoke();
            Destroy(gameObject, 1f);
        } 
    }
    
}

