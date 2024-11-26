using System;
using TMPro;
using UnityEngine;

public class CounterBonus : MonoBehaviour, IBonus
{
    [SerializeField] private TMP_Text _Coin;
    private int _coins;

    public void AddBonus(int bonus)
    {
        _coins += bonus;
        UpdateUI();
    }

    public void Remove(int bonus)
    {
        _coins -= bonus;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _Coin.text = _coins.ToString();
    }
}
