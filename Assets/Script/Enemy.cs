
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _EnemyAnimation;
    [SerializeField] private Health _Health;
    [SerializeField] private LayerMask _HeroLayer;
    
    [SerializeField] private float _PlayerDetect;
    

    private GameObject _hero;
    private bool isAttack;
    
    private void Update()
    {
        DetectHero();
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
    
    private void DetectHero()
    {
        GameObject player = GameObject.FindWithTag("Hero");
        if (player != null)
        {
            float distanceHero = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log("rasstoyanie");
            if (distanceHero <= _PlayerDetect)
            {
                AttackHero();
                Debug.Log("naiden");
            }
            else
            {
                Debug.Log("ne naiden");
            }
        }
        
        
        //float distanceHero = Vector2.Distance(transform.position, _hero.transform.position);
        
        // Collider2D heroCollider = Physics2D.OverlapCircle(transform.position, _PlayerDetect, _HeroLayer);
        // if (heroCollider != null)
        // {
        //     Debug.Log("gggggg");
        //     _hero = heroCollider.gameObject;
        //     _EnemyAnimation.SetBool("isAttack", true);
        //     AttackHero();
        // }
        // else
        // {
        //     Debug.Log("999999");
        // }
    }

    private void AttackHero()
    {
        if (isAttack && _hero != null)
        {
            float ramdomDamage = Random.Range(8, 17);
            _hero.GetComponent<Health>().TakeDamage(ramdomDamage);
            _EnemyAnimation.SetTrigger("Attack");
            isAttack = false;
            Invoke("ResetAttack",2f);
        }
    }

    private void ResetAttack()
    {
        isAttack = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _PlayerDetect);
    }
}

