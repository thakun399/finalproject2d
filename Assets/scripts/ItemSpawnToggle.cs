using UnityEngine;

public class ItemSpawnToggle : MonoBehaviour
{
    public GameObject wallPrefab;  // Prefab ของกำแพง
    private GameObject currentWall;
    public float respawnTime = 20f;

    void Start()
    {
        SpawnWall(); // เริ่มเกม -> สร้างกำแพงแรก
    }

    void SpawnWall()
    {
        // สร้างกำแพงใหม่ที่ตำแหน่งของตัวเอง
        currentWall = Instantiate(wallPrefab, transform.position, Quaternion.identity);

        // ส่งตัวเองให้ Wall รู้ว่าให้แจ้งเมื่อถูกทำลาย
        SuperPower wallScript = currentWall.GetComponent<SuperPower>();
        if (wallScript != null)
        {
            wallScript.respawner = this; // กำหนดให้ respawner นี้คือ ItemSpawnToggle
        }
    }

    public void OnWallDestroyed()
    {
        // ถูกเรียกจาก Wall เมื่อโดนทำลาย
        Invoke(nameof(SpawnWall), respawnTime); // สร้างกำแพงใหม่หลังจาก 20 วินาที
    }
}