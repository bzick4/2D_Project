using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadSaveCheckpoint : MonoBehaviour
{
    private Health _heroHealth;
    private Transform _heroTranform;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _heroHealth = collision.GetComponentInParent<Health>();
            _heroTranform = collision.GetComponentInParent<Transform>();
            
            Debug.Log("Герой вошел в триггер контрольной точки.");
            Save(collision.gameObject);
        }
    }

    private void Save(GameObject hero)
    {
        if (_heroHealth == null)
        {
            Debug.LogError("Компонент Health не найден на герое! Убедитесь, что скрипт Health добавлен к объекту героя.");
            return;
        }

        // Сохранение текущего здоровья игрока
        PlayerPrefs.SetFloat("PlayerCurrentHealth", _heroHealth._currentHealth);

        // Сохранение позиции игрока
        PlayerPrefs.SetFloat("PlayerPositionX", hero.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", hero.transform.position.y);

        PlayerPrefs.Save(); // Сохраняем данные на устройстве
        Debug.Log("Контрольная точка сохранена успешно.");
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
        var loader = FindObjectOfType<LoadSaveCheckpoint>();
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

