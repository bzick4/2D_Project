using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine;

public class ChestCoin : MonoBehaviour
{
    
    [SerializeField] private GameObject _Button, _CoinEffect;
    [SerializeField] private Chest _Chest;
    private CounterBonus _counterBonus;
    

    private void Awake()
    {
        _counterBonus = GetComponentInParent<CounterBonus>();
    }
        
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _Button.SetActive(true);
            PressE();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _Button.SetActive(false);
        }
    }

    private void PressE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _Chest.Open();
            _counterBonus.AddBonus(10);
            _Button.SetActive(false);
            _CoinEffect.SetActive(true);
            Destroy(gameObject,3);
        } 
    } 
}
