using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private int _CoinValue;
    [SerializeField] private GameObject _DestroyEffect;

    private CounterBonus _counterBonus;
    
    private void Awake()
    {
        _counterBonus = GetComponentInParent<CounterBonus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            if (_counterBonus != null)
            {
                _counterBonus.AddBonus(_CoinValue);
                DestroyCoin();
                DestroyEffect();
            }
        }
    }
   
    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
    
    private void DestroyEffect()
    {
        _DestroyEffect.SetActive(true);
    }
    
}
