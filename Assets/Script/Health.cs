using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _MaxHealth;
    [SerializeField] private Image _ImageHP;
    public float _currentHealth{ get; private set;}

    private bool isAlive;
    
    private  void Awake()
    {
        if (PlayerPrefs.HasKey("Health"))
        {
            _currentHealth = PlayerPrefs.GetFloat("Health");
        }
        _currentHealth = _MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _ImageHP.fillAmount = _currentHealth / _MaxHealth;
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
