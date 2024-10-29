using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{
   // private GameObject _Player,_Enemy; 
    [SerializeField] private Button _RockButton,_PaperButton, _ScissorsButton;
    private Animator _enemyAnimator, _heroAnimator;
    private Health _heroHealth, _enemyHealth;

    private string[] _options = { "Rock", "Paper", "Scissors" };
    private string _playerChoice;
    private string _enemyChoice;
    
    private void Awake()
    {
        _enemyHealth = GetComponent<Health>();
        _enemyAnimator = GetComponentInChildren<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            Debug.Log(collision.gameObject.name);
            _heroAnimator = GetComponent<Animator>();
            _heroHealth = collision.GetComponentInParent<Health>();
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
            //_enemyHealth.ApplyDamage(damage: 50);
           // Invoke("StopAnimation", 0.8f);
        }
        else
        {
            Debug.Log("Враг победил!");
            
            //_enemyAnimator.SetTrigger("Attack");
            //_heroHealth.ApplyDamage(damage: 50);
            //StartCoroutine(StopAnimationEnemy(0.8f));
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