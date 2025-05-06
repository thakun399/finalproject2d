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
    
    
    
    [Header("Audio")]//กั้ง
    public AudioClip monsterDeathSound;
    private AudioSource audioSource;
    public AudioClip gameOverSound; //  เพิ่มเสียงตอนแพ้
    public AudioClip victorySound; // เพิ่มเสียงตอนชนะ
    public AudioClip backgroundMusic; // เพลงพื้นหลัง
    private AudioSource musicSource;  // AudioSource สำหรับเพลงพื้นหลัง
    [Range(0f, 1f)] public float musicVolume = 0.5f;  // ควบคุม

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
        audioSource = GetComponent<AudioSource>();//กั้ง
        // สร้าง AudioSource สำหรับเพลงพื้นหลัง
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;  // ทำให้เพลงเล่นวน
        musicSource.volume = musicVolume;  // ตั้งค่าความดังของเพลง
        musicSource.Play();  // เริ่มเพลงพื้นหลัง
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;
        // หยุดเพลงพื้นหลังเมื่อแพ้
        if (musicSource != null)
            musicSource.Stop();

        
        //  เล่นเสียงตอนแพ้
        if (gameOverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }

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
        // หยุดเพลงพื้นหลังเมื่อชนะ
        if (musicSource != null)
            musicSource.Stop();
        //  เล่นเสียงตอนชนะ
        if (victorySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(victorySound);
        }

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
        
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
    public void PlayMonsterDeathSound()//กั้ง
    {
        if (monsterDeathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(monsterDeathSound);
        }
    }
}
