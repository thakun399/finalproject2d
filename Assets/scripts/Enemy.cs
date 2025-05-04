using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public int maxHealth = 40;
    private int currentHealth;

    public int scoreValue = 10; // 💥 คะแนนของศัตรูตัวนี้
    private GameController gameController;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage! Remaining: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died!");

        // 💥 เพิ่มคะแนนเมื่อศัตรูตาย
        if (gameController != null)
        {
            gameController.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            Tower tower = collision.GetComponent<Tower>();
            if (tower != null)
            {
                tower.TakeDamage(damage);
            }

            Destroy(gameObject); // ทำลายตัวเองหลังจากชน
        }
    }
}