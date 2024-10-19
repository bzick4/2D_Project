
using System;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float _Damage, _LifeTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_Damage);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
            Destroy(gameObject,_LifeTime);
    }
}
