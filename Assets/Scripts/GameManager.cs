using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int maxHealth = 3;
    public int health = 3;

    public bool isGameOver = false;
    public bool isGameStarted = false;

    private bool isPaused = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI leaderboardText;

    public GameObject gameOverText;
    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject leaderboardPanel;

    private const int LeaderboardSize = 5;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        health = maxHealth;

        UpdateScoreUI();
        UpdateHealthUI();

        if (gameOverText != null) gameOverText.SetActive(false);
        if (startPanel != null) startPanel.SetActive(true);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (leaderboardPanel != null) leaderboardPanel.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (isGameStarted && !isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        isPaused = false;
        Time.timeScale = 1f;

        if (startPanel != null) startPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (leaderboardPanel != null) leaderboardPanel.SetActive(false);
    }

    public void AddScore(int value)
    {
        if (isGameOver || !isGameStarted || isPaused) return;

        score += value;
        UpdateScoreUI();
    }

    public void TakeDamage(int value)
    {
        if (isGameOver || !isGameStarted || isPaused) return;

        health -= value;

        if (health < 0) health = 0;

        UpdateHealthUI();

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void Heal(int value)
    {
        if (isGameOver || !isGameStarted || isPaused) return;

        health += value;

        if (health > maxHealth) health = maxHealth;

        UpdateHealthUI();
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        isPaused = false;
        Time.timeScale = 1f;

        SaveScoreToLeaderboard(score);

        if (gameOverText != null) gameOverText.SetActive(true);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (leaderboardPanel != null) leaderboardPanel.SetActive(false);
    }

    public void TogglePause()
    {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        if (isGameOver || !isGameStarted) return;

        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null) pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null) pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLeaderboard()
    {
        if (startPanel != null) startPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
        if (leaderboardPanel != null) leaderboardPanel.SetActive(true);

        UpdateLeaderboardUI();
    }

    public void CloseLeaderboard()
    {
        if (leaderboardPanel != null) leaderboardPanel.SetActive(false);
        if (startPanel != null) startPanel.SetActive(true);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + health;
    }

    private void SaveScoreToLeaderboard(int newScore)
    {
        int[] scores = new int[LeaderboardSize + 1];

        for (int i = 0; i < LeaderboardSize; i++)
        {
            scores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }

        scores[LeaderboardSize] = newScore;

        System.Array.Sort(scores);
        System.Array.Reverse(scores);

        for (int i = 0; i < LeaderboardSize; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, scores[i]);
        }

        PlayerPrefs.Save();
    }

    private void UpdateLeaderboardUI()
    {
        if (leaderboardText == null) return;

        string text = "Leaderboard\n\n";

        for (int i = 0; i < LeaderboardSize; i++)
        {
            int savedScore = PlayerPrefs.GetInt("HighScore" + i, 0);
            text += (i + 1) + ". " + savedScore + "\n";
        }

        leaderboardText.text = text;
    }
}