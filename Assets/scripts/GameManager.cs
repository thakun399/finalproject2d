using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

    public GameObject gameOverUI; // Assign ใน Inspector

    void Awake()
    {
        // ทำให้ GameManager อยู่ตลอดเกม
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f; // หยุดเวลาเกม
        if (gameOverUI != null)
            gameOverUI.SetActive(true); // แสดง UI Game Over

        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

