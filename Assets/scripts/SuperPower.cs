using UnityEngine;

public class SuperPower : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    
    public ItemSpawnToggle respawner;  

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log($"{gameObject.name} ถูกโจมตี! HP เหลือ: {currentHP}");

        if (currentHP <= 0)
        {
          
            if (respawner != null)
            {
                respawner.OnWallDestroyed(); 
            }
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.damage); 
                
            }
        }
    }
}