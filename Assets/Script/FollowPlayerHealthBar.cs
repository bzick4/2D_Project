using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Transform _Hero; // Перетяните сюда объект игрока
    [SerializeField] private Vector3 _Offset = new Vector3(0, 1, 0); // Смещение над игроком

    void Update()
    {
        if (_Hero!= null)
        {
            // Позиционируем HP Bar на экране на основе позиции игрока
            transform.position = _Hero.position + _Offset;
        }
    }
}
