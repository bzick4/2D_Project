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
        _damageParticle?.Play();
        OnDamage?.Invoke();
        ChekIsAlive();
    }

    public void UpdateHpBar()
    {
        _ImageHP.fillAmount = _currentHealth / _MaxHealth; 
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
