using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public bool isGameOver = false;
    public bool isGameStarted = false;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject startPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();

        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;

        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }
    }

    public void AddScore(int value)
    {
        if (isGameOver || !isGameStarted) return;

        score += value;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        if (!isGameStarted) return;

        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}