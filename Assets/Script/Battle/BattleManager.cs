using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject _Player,_Enemy; 
    [SerializeField] private Button _RockButton,_PaperButton, _ScissorsButton;
    [SerializeField] private Animator _EnemyAnimator, _HeroAnimator;

    private string[] _options = { "Rock", "Paper", "Scissors" }; // Варианты выбора
    private string _playerChoice;
    private string _enemyChoice;
    
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
            _HeroAnimator.SetBool("isAttack", true);
            //_EnemyAnimator.SetTrigger("Hurt");
            GameObject.FindGameObjectWithTag("Enemy");
            _Enemy.GetComponent<Health>().TakeDamage(damage: 50);
            Invoke("StopAnimation", 0.8f);
        }
        else
        {
            Debug.Log("Враг победил!");
            _EnemyAnimator.SetTrigger("Attack");
            _HeroAnimator.SetTrigger("Hurt");
            _Player.GetComponent<Health>().TakeDamage(damage: 50);
            StartCoroutine(StopAnimationEnemy(0.8f));
        }
    }
    
    private void StopAnimation()
    {
        _HeroAnimator.SetBool("isAttack", false);
    }

    private IEnumerator StopAnimationEnemy(float deley)
    {
        yield return new WaitForSeconds(deley);
        _EnemyAnimator.SetTrigger("Idle");
        _HeroAnimator.SetBool("isIdle",true);

    }
    
}