using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour
{
    private Health _heroHealth;
    private Transform _heroTranform;

    private void Awake()
    {
        _heroHealth = GetComponentInParent<Health>();
        _heroTranform = GetComponentInParent<Transform>();

        if (_heroHealth == null)
        {
            Debug.LogError("Компонент Health не найден на объекте героя! Убедитесь, что он добавлен.");
        }

        if (_heroTranform == null)
        {
            Debug.LogError("Компонент Transform не найден на объекте героя! Убедитесь, что он добавлен.");
        }
        
    }


    private void Load()
    {
        if (PlayerPrefs.HasKey("PlayerCurrentHealth"))
        {
            // Восстановление здоровья
            _heroHealth._currentHealth = PlayerPrefs.GetFloat("PlayerCurrentHealth");
            _heroHealth.UpdateHpBar();

            // Восстановление позиции
            float x = PlayerPrefs.GetFloat("PlayerPositionX");
            float y = PlayerPrefs.GetFloat("PlayerPositionY");
            _heroTranform.position = new Vector2(x, y);

            Debug.Log("Состояние игрока успешно загружено.");
        }
        else
        {
            Debug.LogWarning("Контрольная точка не найдена. Сначала сохраните данные.");
        }
    }


    public void OnClickLoad()
    {
        var loader = FindObjectOfType<LoadCheckpoint>();
        if (loader != null)
        {
            loader.Load();
        }
        else
        {
            Debug.LogError("PlayerLoader не найден на сцене!");
        }
    }
    
    
    
    
    
}
