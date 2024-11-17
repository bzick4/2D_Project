using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static event Action OnGiveCoin;
    [SerializeField] private GameObject _DestroyEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            OnGiveCoin?.Invoke();
            DestroyEffect();
            Invoke("DestroyCoin", 0.2f);
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
