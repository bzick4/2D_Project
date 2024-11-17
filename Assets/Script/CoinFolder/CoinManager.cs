using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _Coin;
    public int TotalCoin { get; private set; }
    private void Start()
    {
        CoinScript.OnGiveCoin += OnCoin;
    }
    
    private void OnDisable()
    {
        CoinScript.OnGiveCoin -= OnCoin;
    }
    
    public void OnCoin()
    {
        TotalCoin++;
        _Coin.text = TotalCoin.ToString();
    }
}
