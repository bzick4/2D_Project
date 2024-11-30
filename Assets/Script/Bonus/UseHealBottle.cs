using System;
using UnityEngine;

public class UseHealBottle : MonoBehaviour
{
    [SerializeField] private HealBottleManager _TotalBottle, _HealBottle;
    private Health _heroHealth;
    [SerializeField] private SaveManager _manager;
    private void Awake()
    {
        _heroHealth = GetComponent<Health>();
    }

    private void Update()
    {
        DrinkHealBottle();
        Death();
        // Save();
        // Load();
        Cheat();
    }
    private void CureHero()
    {
        _heroHealth?.ApplyDamage(-40);
    }
    
    private void DrinkHealBottle()
    {
        if (Input.GetKeyDown(KeyCode.I) && _TotalBottle.TotalHealBottle > 0)
        {
            _HealBottle.Remove(1);
            CureHero();
        }
    }
    
    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _heroHealth?.ApplyDamage(50);
        }
    }
    
    // private void Save()
    // {
    //     if (Input.GetKeyDown(KeyCode.N))
    //     {
    //         _manager.SaveGame();
    //     }
    // }
    //
    // private void Load()
    // {
    //     if (Input.GetKeyDown(KeyCode.M))
    //     {
    //         _manager.LoadGame();
    //     } 
    // }
    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _HealBottle.AddBonus(10);
        } 
    }
    
    
}
