
using UnityEngine;

public class ThrowableObject : MonoBehaviour, IThrowable
{
    
    public void Launch(Vector2 targetPos, float speed)
    {
        Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            
        }
    }
}
