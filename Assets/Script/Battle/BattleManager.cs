using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Button _RockButton,_PaperButton, _ScissorsButton;
    
    private Animator _enemyAnimator, _heroAnimator;
    private Health _heroHealth, _enemyHealth;
    
    private string _playerChoice, _enemyChoice;
    private bool isBattle = false;
    private float _randomDamagebleHero;
    
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
    
    private  void PlayerChoice(string choice)
    {
         _playerChoice = choice;
        Debug.Log("Игрок выбрал: " + _playerChoice);

        EnemyChoice();
        DetermineWinner();
        RandomDamagePlayer(_randomDamagebleHero);
    }
    
    private void EnemyChoice()
    {
        int randomChoice = Random.Range(0, 100);
        if (randomChoice >= 0 && randomChoice <= 45)
        {
            _enemyChoice = "Rock";
        }
        else if (randomChoice >=46 && randomChoice <=88)
        {
            _enemyChoice = "Scissors";
        }
        else if(randomChoice >=89 && randomChoice <=99)
        {
            _enemyChoice = "Paper";
        }
        Debug.Log("Враг выбрал: " + _enemyChoice);
    }
    
    private void RandomDamagePlayer(float random)
    {
        random = Random.Range(0, 1001);
        if (random >= 0 && random <= 333)
        {
            _randomDamagebleHero = 40;
        }
        else if(random >=334 && random <=666)
        {
            _randomDamagebleHero = 47;
        }
        else if (random >= 667 && random <= 999)
        {
            _randomDamagebleHero = 55;
        }
        else if(random==1000)
        {
            _randomDamagebleHero = 100;
            {
                Debug.Log($"CRITICAL DAMAGE{_randomDamagebleHero}");
            }
        } 
    }
    
    private void DetermineWinner()
    {
        float randomDamagebleEnemy = Random.Range(20, 44);
        
            if (_playerChoice == _enemyChoice)
            {
                Debug.Log("Ничья!");
            }
            else if ((_playerChoice == "Rock" && _enemyChoice == "Scissors") ||
                     (_playerChoice == "Paper" && _enemyChoice == "Rock") ||
                     (_playerChoice == "Scissors" && _enemyChoice == "Paper"))
            {
                Debug.Log("Игрок победил!"); 
                _heroAnimator?.SetBool("isAttack", true); 
                _enemyHealth?.ApplyDamage(_randomDamagebleHero); 
                Debug.Log($"Герой нанес {_randomDamagebleHero} урона");
                Invoke("StopAnimation", 0.8f);
            }
            else
            {
                Debug.Log("Враг победил!");
                _enemyAnimator?.SetTrigger("Attack");
                _heroHealth?.ApplyDamage(randomDamagebleEnemy);
                Debug.Log($"Враг нанес {randomDamagebleEnemy} урона");
                StartCoroutine(StopAnimationEnemy(0.8f)); 
            }
    }
    
    private void StopAnimation()
    {
        _heroAnimator?.SetBool("isAttack", false);
    }

    private IEnumerator StopAnimationEnemy(float deley)
    {
        yield return new WaitForSeconds(deley);
        _enemyAnimator?.SetTrigger("Idle");
    }
    
}