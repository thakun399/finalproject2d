using UnityEngine;

public class SuperPower : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    // เพิ่มตัวแปร respawner ที่จะเชื่อมโยงกับ WallRespawner
    public ItemSpawnToggle respawner;  // เปลี่ยนชื่อเป็น ItemSpawnToggle เพื่อใช้กับฟังก์ชัน

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
            // เมื่อกำแพงตาย, เรียกฟังก์ชันจาก respawner (ItemSpawnToggle) เพื่อให้มัน respawn
            if (respawner != null)
            {
                respawner.OnWallDestroyed(); // เรียกการ respawn
            }
            Destroy(gameObject); // ทำลายกำแพง
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.damage); // รับดาเมจจากศัตรู
                // ศัตรูไม่ถูกทำลาย
            }
        }
    }
}