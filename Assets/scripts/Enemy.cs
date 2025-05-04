using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;

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