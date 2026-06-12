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

    public GameObject gameOverText;
    public GameObject startPanel;
    public GameObject pausePanel;

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

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
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

        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
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

        if (health < 0)
        {
            health = 0;
        }

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

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthUI();
    }

    public void GameOver()
    {
        isGameOver = true;
        isPaused = false;
        Time.timeScale = 1f;

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isGameOver || !isGameStarted) return;

        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateHealthUI()
    {
        healthText.text = "HP: " + health;
    }
}