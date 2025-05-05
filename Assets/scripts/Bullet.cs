using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    public float lifetime = 2f;

    void Start()
    {
        // ทำลายตัวเองหลังจากเวลา
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // ทำลายกระสุนเมื่อโดนศัตรู
            Destroy(gameObject);
        }
    }
}