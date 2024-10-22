
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _EnemyAnimation;
    [SerializeField] private Health _Health;
    
    private void Update()
    {
        Health();
    }

    private void Health()
    {
        if (_Health._currentHealth <=0)
        {
            _EnemyAnimation.SetTrigger("Dead");
            Destroy(gameObject, 1f);
        } 
    }
    
    
}

