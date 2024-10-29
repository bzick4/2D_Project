using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject _ButtonBattle, _PanelBattle;
    private bool isActive = true;
    

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (isActive)
            {
                _ButtonBattle.SetActive(true);
            }
            PressBattleBotton();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _ButtonBattle.SetActive(false);
            _PanelBattle.SetActive(false);
            isActive = true;
        }
    }

    private void PressBattleBotton()
    {
        if (Input.GetKey(KeyCode.E))
        {
            _PanelBattle.SetActive(true);
            _ButtonBattle.SetActive(false);
            isActive = false;
        }
    }
}