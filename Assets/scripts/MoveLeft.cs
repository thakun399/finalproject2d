using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Translate(Vector2.left * speed*Time.deltaTime);
    }

    
}