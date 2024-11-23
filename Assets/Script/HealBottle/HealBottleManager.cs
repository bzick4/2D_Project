using TMPro;
using UnityEngine;

public class HealBottleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _HealBottle;
    
    public int TotalHealBottle { get; private set; }
    
    private void Start()
    {
        Enemy.OnGiveHealBottle += OnHealBottle;
        UseHealBottle.OnDrinkHealBottle += OnDrink;
    }
    
    private void OnDisable()
    {
        Enemy.OnGiveHealBottle -= OnHealBottle;
        UseHealBottle.OnDrinkHealBottle -= OnDrink;
    }
    
    public void OnHealBottle()
    {
        TotalHealBottle++;
        _HealBottle.text = TotalHealBottle.ToString();
    }

    public void OnDrink()
    {
        TotalHealBottle--;
        _HealBottle.text = TotalHealBottle.ToString();
    }
    
}
