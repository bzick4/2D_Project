
using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject _ButtonBattle, _PanelBattle;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _ButtonBattle.SetActive(true);
            PressBattleBotton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _ButtonBattle.SetActive(false);
        }
    }

    private void PressBattleBotton()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _PanelBattle.SetActive(true);
            _ButtonBattle.SetActive(false);
        }
    }
    
    
    
    
}