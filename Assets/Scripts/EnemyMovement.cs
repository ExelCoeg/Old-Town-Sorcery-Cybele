using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
   
    public float speed;
    public float distanceBetween;
    private float distance;
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        distance = player.transform.position.x - transform.position.x;
        // distance = Vector2.Distance(transform.position, player.transform.position);
        // Vector2 direction = player.transform.position - transform.position;
        // direction.Normalize();
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // print(distance);
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
        transform.eulerAngles = distance < 0 ? Vector2.up * -180: Vector2.zero;

    }
}
