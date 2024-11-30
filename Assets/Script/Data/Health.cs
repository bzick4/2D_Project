using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _MaxHealth;
    [SerializeField] private Image _ImageHP;
    
    private ParticleSystem _damageParticle;
    private Animator _animator;
    private bool isAlive;
    
    public float _currentHealth{ get; set;}
    public static Action OnDamage;

    private void Update()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _MaxHealth);
        
    }

    private  void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _damageParticle = GetComponentInChildren<ParticleSystem>();
        _currentHealth = _MaxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        UpdateHpBar();
        _animator?.SetTrigger("Hurt");
        Invoke("StopAnimationHurt",0.8f);
        _damageParticle?.Play();
        OnDamage?.Invoke();
        ChekIsAlive();
    }

    public void UpdateHpBar()
    {
        _ImageHP.fillAmount = _currentHealth / _MaxHealth; 
    }
    
    private void StopAnimationHurt()
    {
        _animator?.SetTrigger("Idle");
    }
    
    private void ChekIsAlive()
    {
        if (_currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }
    
    }
