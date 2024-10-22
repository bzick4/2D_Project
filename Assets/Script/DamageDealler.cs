
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _AttackDamageMax,_AttackDamageMin,_AttackRange, _LifeTime;
    [SerializeField] private LayerMask _TargetLayer;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            float ramdomDamage = Random.Range(_AttackDamageMin, _AttackDamageMax);
          collision.gameObject.GetComponent<Health>().TakeDamage(ramdomDamage);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
            Destroy(gameObject,_LifeTime);
    }
}
