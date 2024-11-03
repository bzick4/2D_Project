using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Button _RockButton,_PaperButton, _ScissorsButton;
    private Animator _enemyAnimator, _heroAnimator;
    private Health _heroHealth, _enemyHealth;

    private string[] _options = { "Rock", "Paper", "Scissors" };
    private string _playerChoice, _enemyChoice;
    
    private void Awake()
    {
        _enemyHealth = GetComponent<Health>();
        _enemyAnimator = GetComponentInChildren<Animator>();
        
        if (_enemyHealth == null)
        {
            Debug.Log("health vraga ne naiden");
        }
        
        if (_enemyAnimator == null)
        {
            Debug.Log("animator vraga ne naiden");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _heroAnimator = collision.GetComponentInChildren<Animator>();
            if (_heroAnimator == null)
            {
                Debug.Log("animator hero ne naiden");
            }
            else
            {
                Debug.Log("animator hero naiden");
            }
            _heroHealth = collision.GetComponentInParent<Health>();
            if (_heroHealth == null)
            {
                Debug.Log("health hero ne naiden");
            }
            else
            {
                Debug.Log("health hero naiden");
            }
        }
    }

    private void Start()
    { 
        _RockButton.onClick.AddListener(() => PlayerChoice("Rock"));
        _PaperButton.onClick.AddListener(() => PlayerChoice("Paper"));
        _ScissorsButton.onClick.AddListener(() => PlayerChoice("Scissors"));
    }
    
    // Выбор игрока
    private  void PlayerChoice(string choice)
    {
        _playerChoice = choice;
        Debug.Log("Игрок выбрал: " + _playerChoice);

        EnemyChoice();
        
        DetermineWinner();
    }

    // Выбор врага случайным образом
    private void EnemyChoice()
    {
        int randomIndex = Random.Range(0, _options.Length);
        _enemyChoice = _options[randomIndex];
        Debug.Log("Враг выбрал: " + _enemyChoice);
    }

    // Определение победителя
    private void DetermineWinner()
    {
            if (_playerChoice == _enemyChoice)
            {
                Debug.Log("Ничья!");
            }
            else if ((_playerChoice == "Rock" && _enemyChoice == "Scissors") ||
                     (_playerChoice == "Paper" && _enemyChoice == "Rock") ||
                     (_playerChoice == "Scissors" && _enemyChoice == "Paper"))
            {
                Debug.Log("Игрок победил!"); 
                _heroAnimator.SetBool("isAttack", true); 
                _enemyHealth.ApplyDamage(50); 
                Invoke("StopAnimation", 0.8f);
            }
            else
            {
                Debug.Log("Враг победил!");
                _enemyAnimator.SetTrigger("Attack");
                _heroHealth.ApplyDamage(50);
                StartCoroutine(StopAnimationEnemy(0.8f)); 
            }
    }
    
    private void StopAnimation()
    {
        _heroAnimator.SetBool("isAttack", false);
        _enemyAnimator.SetTrigger("Idle");
    }

    private IEnumerator StopAnimationEnemy(float deley)
    {
        yield return new WaitForSeconds(deley);
        _enemyAnimator.SetTrigger("Idle");
        _heroAnimator.SetBool("isIdle",true);
    }
    
}