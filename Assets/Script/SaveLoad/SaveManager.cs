using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Health _HeroHealth; // Ссылка на здоровье игрока
    [SerializeField] private Transform _HeroTransform; // Ссылка на объект игрока
    [SerializeField] private CounterBonus _Coins; // Количество монет
    [SerializeField] private HealBottleManager _HealthBottle; // Количество аптечек
    [SerializeField] private PlayerMovement _Animator;
    //[SerializeField] private List<Enemy> enemies; // Список врагов на сцене

    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Application.dataPath + "/save.json";
    }

    // Метод для сохранения
    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            HeroHealth = _HeroHealth._currentHealth,
            Position = new float[3]
            {
                _HeroTransform.position.x,
                _HeroTransform.position.y,
                _HeroTransform.position.z
            },
            Coins = _Coins._coins,
            HealthBottle = _HealthBottle.TotalHealBottle,
            Animator = _Animator._animator
           // EnemyHealths = new List<int>() // Сохраняем здоровье всех врагов
        };

        // foreach (Enemy enemy in enemies)
        // {
        //     data.EnemyHealths.Add(enemy.GetComponent<Health>()); // Берём здоровье каждого врага
        // }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json); 

        Debug.Log("Игра сохранена в " + saveFilePath);
    }
    
    public void LoadGame()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Сохранение не найдено!");
            return;
        }
        
        string json = File.ReadAllText(saveFilePath); 
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        
        _HeroHealth._currentHealth = data.HeroHealth;
        _HeroHealth.UpdateHpBar();
        Debug.Log($"Health {_HeroHealth}");
        
        _HeroTransform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);
        
        
        _Coins._coins = data.Coins;
        _Coins.UpdateUI();
        
        _HealthBottle.TotalHealBottle = data.HealthBottle;
        _HealthBottle.UpdateUI();

        _Animator.isDead = false;
        _Animator._PanelLose.SetActive(false);
        _Animator.IdleAnim();
        
        Debug.Log($"coin {data.Coins}, bottle {data.HealthBottle}");

        // // Восстанавливаем здоровье всех врагов
        // for (int i = 0; i < enemies.Count; i++)
        // {
        //     if (i < data.EnemyHealths.Count)
        //     {
        //         enemies[i].Health = data.EnemyHealths[i];
        //     }
        // }
        
        Debug.Log("Игра загружена!");
    }
}

// Класс данных для сохранения
[System.Serializable]
public class SaveData
{
    public float HeroHealth;
    public float[] Position;
    public int Coins;
    public int HealthBottle;
    public Animator Animator;
    //public List<int> EnemyHealths; // Здоровье врагов
}

