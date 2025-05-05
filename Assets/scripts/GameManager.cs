using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

    [Header("UI Elements")]
    public GameObject gameOverUI;
    public GameObject victoryUI;  
    public TMP_Text finalScoreText;

    [Header("Score")]
    public int score = 0;
    public TMP_Text scoreText;

    [Header("Win Condition")]
    public int scoreToWin = 2000;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
        victoryUI.SetActive(false);  
        gameOverUI.SetActive(false);  
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        if (gameOverUI != null)
            gameOverUI.SetActive(true);  
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score.ToString();

        Debug.Log("Game Over!");
    }

    public void WinGame()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        if (victoryUI != null)
            victoryUI.SetActive(true); 

        if (finalScoreText != null)
            finalScoreText.text = "🎉 VICTORY!\nFinal Score: " + score.ToString();  

        Debug.Log("You Win!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();

        if (score >= scoreToWin)
        {
            WinGame();  
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
