using System;
using UnityEngine;

public class UseHealBottle : MonoBehaviour
{
    [SerializeField] private HealBottleManager _TotalBottle;
    
    private Health _heroHealth;
    public static event Action OnDrinkHealBottle;

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
            OnDrinkHealBottle?.Invoke();
            CureHero();
        }
    }
    
    private void CureHero()
    {
        _heroHealth?.ApplyDamage(-40);
    }
}
