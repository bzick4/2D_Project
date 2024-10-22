using System.Collections;
using UnityEngine;
using UnityEngine.UI; // для работы с кнопками и UI

public class BattleManager : MonoBehaviour
{
    public GameObject player; // Игрок на сцене боя
    public GameObject enemy;  // Враг на сцене боя
    public GameObject playerController;

    public Button rockButton;  // Кнопка "Камень"
    public Button paperButton; // Кнопка "Бумага"
    public Button scissorsButton; // Кнопка "Ножницы"

    private string[] options = { "Rock", "Paper", "Scissors" }; // Варианты выбора
    private string playerChoice;
    private string enemyChoice;

    [SerializeField] private Animator _EnemyAnimator, _HeroAnimator;

    void Start()
    {
        // Привязываем кнопки к методам
        rockButton.onClick.AddListener(() => PlayerChoice("Rock"));
        paperButton.onClick.AddListener(() => PlayerChoice("Paper"));
        scissorsButton.onClick.AddListener(() => PlayerChoice("Scissors"));
    }

    // Выбор игрока
    void PlayerChoice(string choice)
    {
        playerChoice = choice;
        Debug.Log("Игрок выбрал: " + playerChoice);

        EnemyChoice();
        DetermineWinner();
    }

    // Выбор врага случайным образом
    void EnemyChoice()
    {
        int randomIndex = Random.Range(0, options.Length);
        enemyChoice = options[randomIndex];
        Debug.Log("Враг выбрал: " + enemyChoice);
    }

    // Определение победителя
    void DetermineWinner()
    {
        if (playerChoice == enemyChoice)
        {
            Debug.Log("Ничья!");
        }
        else if ((playerChoice == "Rock" && enemyChoice == "Scissors") ||
                 (playerChoice == "Paper" && enemyChoice == "Rock") ||
                 (playerChoice == "Scissors" && enemyChoice == "Paper"))
        {
            Debug.Log("Игрок победил!");
            _HeroAnimator.SetBool("isAttack", true);
            //_EnemyAnimator.SetTrigger("Hurt");
            enemy.GetComponent<Health>().TakeDamage(damage: 50);
            Invoke("StopAnimation", 0.8f);

        }
        else
        {
            Debug.Log("Враг победил!");
            _EnemyAnimator.SetTrigger("Attack");
            _HeroAnimator.SetTrigger("Hurt");
            player.GetComponent<Health>().TakeDamage(damage: 50);
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