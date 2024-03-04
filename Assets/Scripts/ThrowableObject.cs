
using UnityEngine;

public class ThrowableObject : MonoBehaviour, IThrowable
{
    Vector2 targetPos;
    float speed;
    bool isActivated = false;
    private void Update()
    {
        if (isActivated)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
        { 
            isActivated = false;
        }
    }
    public void Launch(Vector2 targetPos, float speed)
    {
        isActivated = true;
        this.targetPos = targetPos;
        this.speed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            isActivated = false;
        }
    }
}
