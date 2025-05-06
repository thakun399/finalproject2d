using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target; //target sprite
    [SerializeField] Rigidbody2D bulletPrefab;

    [SerializeField] float cooldownTime = 1f; // เวลาคูลดาวน์ (ระยะเวลารอระหว่างการยิง)
    private float nextFireTime = 0f; // เวลาที่สามารถยิงได้ถัดไป
    
    [SerializeField] AudioClip shootSound;//ตรงนี้เพิ่มโดยกั้ง
    private AudioSource audioSource;
    
    void Start()//ตรงนี้เพิ่มโดยกั้ง
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            // รีเซ็ทเวลา nextFireTime เพื่อให้เกิดคูลดาวน์
            nextFireTime = Time.time + cooldownTime;

            //shoot raycast to detect mouse clicked position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            //get click point
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            //if hit object with collider
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("hit " + hit.collider.name);

                //calculate projectile velocity
                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                //shoot bullet prefab using Rigidbody2D
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                //add projectile velocity vector to the bullet rigidbody
                shootBullet.velocity = projectileVelocity; //ใช้ velocity แทน linearVelocity
                audioSource.PlayOneShot(shootSound);//ตรงนี้เพิ่มโดยกั้ง
            }
            
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        //find velocity of x and y axis
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        //get projectile vector
        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }
    
}
