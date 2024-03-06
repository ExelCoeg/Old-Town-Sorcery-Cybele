
using UnityEngine;
public class EnemyCombat : MonoBehaviour
{
    public int attackDamage;
    float attackTimer;
    [SerializeField] float attackCooldown;
    public float attackRange;
    public Transform attackPoint;

    public LayerMask playerLayer;
    
    private void Update() {
       
       attackTimer -= Time.deltaTime;
        Vector2 direction = transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange, playerLayer);
        
        Debug.DrawRay(attackPoint.position, direction * hit.distance, Color.green);
        if(hit.collider != null && attackTimer <= 0){
            attackTimer = attackCooldown;
            hit.collider.gameObject.GetComponent<PlayerHealth>().currentHealth -=  attackDamage - (int) hit.distance ;
            // print(hit.distance);

            return;
        }
        
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
            
    //         collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= attackDamage;
    //      }
    // }
    
}
