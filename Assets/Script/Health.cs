using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _MaxHealth;
    [SerializeField] private Image _ImageHP;
    public float _currentHealth{ get; private set;}

    public bool isAlive { get; private set;}


    private  void Awake()
    {
        _currentHealth = _MaxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _ImageHP.fillAmount = _currentHealth / _MaxHealth;
        ChekIsAlive();
        Debug.Log(_currentHealth);
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
