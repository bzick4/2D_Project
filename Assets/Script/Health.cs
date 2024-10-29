using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _MaxHealth;
    [SerializeField] private Image _ImageHP;
    
    private Animator _animator;
    private bool isAlive;
    
    public float _currentHealth{ get; private set;}
    public static Action OnDamage;
    
    private  void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        
        if (PlayerPrefs.HasKey("Health"))
        {
            _currentHealth = PlayerPrefs.GetFloat("Health");
        }
        _currentHealth = _MaxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        _ImageHP.fillAmount = _currentHealth / _MaxHealth;
        _animator.SetTrigger("Hurt");
        OnDamage?.Invoke();
        PlayerPrefs.SetFloat("Health", _currentHealth);
        PlayerPrefs.Save();
        ChekIsAlive();
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
