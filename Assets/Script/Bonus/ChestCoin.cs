using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine;

public class ChestCoin : MonoBehaviour
{
    
    [SerializeField] private GameObject _Button, _CoinEffect;
    [SerializeField] private Chest _Chest;
    private CounterBonus _counterBonus;
    [SerializeField] private int _Coin;
    private bool isBonus=true;
    

    private void Awake()
    {
        _counterBonus = GetComponentInParent<CounterBonus>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            if (isBonus)
            {
                _Button.SetActive(true);
            }
            PressE();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _Button.SetActive(false);
            isBonus = true;
        }
    }
    
    private void PressE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _Chest.Open();
            _counterBonus.AddBonus(_Coin);
            _CoinEffect.SetActive(true);
            Destroy(gameObject,3);
        } 
    } 
}
