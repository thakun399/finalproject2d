using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
   
    void Update()
    {
        transform.Translate(Vector2.left * speed*Time.deltaTime);
    }

    
}