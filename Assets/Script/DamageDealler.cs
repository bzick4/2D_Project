
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _AttackDamageMax,_AttackDamageMin,_AttackRange, _LifeTime;
    [SerializeField] private LayerMask _TargetLayer;

    // public void DealDamage()
    // {
    //     Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, _AttackRange, _TargetLayer);
    //
    //     foreach (Collider2D target in hitTargets)
    //     {
    //         Health targetHealth = target.GetComponent<Health>();
    //         if (targetHealth != null)
    //         {
    //             float ramdomDamage = Random.Range(_AttackDamageMin, _AttackDamageMax);
    //             targetHealth.TakeDamage(ramdomDamage);
    //         }
    //     }
    // }
    
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
