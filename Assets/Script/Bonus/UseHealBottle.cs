using System;
using UnityEngine;

public class UseHealBottle : MonoBehaviour
{
    [SerializeField] private HealBottleManager _TotalBottle, _HealBottle;
    private Health _heroHealth;

    private void Awake()
    {
        _heroHealth = GetComponent<Health>();
    }

    private void Update()
    {
        DrinkHealBottle();
    }
    
    private void DrinkHealBottle()
    {
        if (Input.GetKey(KeyCode.I) && _TotalBottle.TotalHealBottle > 0)
        {
            _HealBottle.Remove(1);
            CureHero();
        }
    }
    
    private void CureHero()
    {
        _heroHealth?.ApplyDamage(-40);
    }
}
