using UnityEngine;
using UnityEngine.UI;


public class Battle : MonoBehaviour
{
    [SerializeField] private Text resultText;
    [SerializeField] private Button[] choiceButtons; 
    [SerializeField] private Button continueButton; 
    [SerializeField] private Text timerText;

    private string[] choices = { "Rock", "Paper", "Scissors" };
    private string playerChoice;
    private string enemyChoice;
    private int playerWins = 0;
    private int enemyWins = 0;
    private float timer = 5f;
    private bool roundActive = false;

    void Start()
    {
        continueButton.gameObject.SetActive(false);
        foreach (Button button in choiceButtons)
        {
            button.onClick.AddListener(() => PlayerChoose(button.name));
        }
        StartRound();
    }

    void Update()
    {
        if (roundActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timer).ToString();

            if (timer <= 0)
            {
                EndRound();
            }
        }
    }

    void StartRound()
    {
        timer = 5f;
        roundActive = true;
        continueButton.gameObject.SetActive(false);
        playerChoice = "";
        enemyChoice = choices[Random.Range(0, choices.Length)];
        resultText.text = "Choose Rock, Paper, or Scissors!";
    }

    void EndRound()
    {
        roundActive = false;
        if (playerChoice == "")
        {
            resultText.text = "You didn't choose!";
            continueButton.gameObject.SetActive(true);
            return;
        }

       
        if (playerChoice == enemyChoice)
        {
            resultText.text = "It's a draw! Try again.";
        }
        else
        {
            DetermineWinner();
        }
        continueButton.gameObject.SetActive(true);
    }

    void PlayerChoose(string choice)
    {
        playerChoice = choice;
        resultText.text = "You chose " + playerChoice + ". Waiting for the result...";
    }

    void DetermineWinner()
    {
        
        if ((playerChoice == "Rock" && enemyChoice == "Scissors") ||
            (playerChoice == "Scissors" && enemyChoice == "Paper") ||
            (playerChoice == "Paper" && enemyChoice == "Rock"))
        {
            playerWins++;
            resultText.text = "You win this round!";
        }
        else
        {
            enemyWins++;
            resultText.text = "Enemy wins this round!";
        }

        
        if (playerWins == 2)
        {
            resultText.text = "You win the game!";
            continueButton.gameObject.SetActive(false);
        }
        else if (enemyWins == 2)
        {
            resultText.text = "Enemy wins the game!";
            continueButton.gameObject.SetActive(false);
        }
    }

    public void OnContinueButton()
    {
        if (playerWins < 2 && enemyWins < 2)
        {
            StartRound();
        }
    }
}