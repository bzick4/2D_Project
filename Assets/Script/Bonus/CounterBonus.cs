using System;
using TMPro;
using UnityEngine;

public class CounterBonus : MonoBehaviour, IBonus
{
    [SerializeField] private TMP_Text _Coin;
    [SerializeField] private TMP_Text _FinalCoin;
    public int _coins { get; set; }

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

    public void UpdateUI()
    {
        _FinalCoin.text = _coins.ToString();
        _Coin.text = _coins.ToString();
    }
}
