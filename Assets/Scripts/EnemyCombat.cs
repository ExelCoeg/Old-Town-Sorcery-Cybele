
using UnityEngine;
public class EnemyCombat : MonoBehaviour
{
    EnemyName enemyName;
    [Header("Attack Attributes")]
    public int attackDamage;
    float attackTimer;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackRange = 1.5f;
    
    public Transform attackPoint;

    public LayerMask playerLayer;

    /*--------animation variable ------------*/
    private string wolfAttack_parameter = "wolf_attack";
    private string wolfMiniBossAttack_parameter = "wolf_mini_boss_attack";
    private string currentAnimation;
    
    private void Start() {
        attackTimer = attackCooldown + 2;
        enemyName = GetComponent<EnemyMovement>().enemyName;
    }
    private void Update() {
       
        attackTimer -= Time.deltaTime;
        Vector2 direction = transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange, playerLayer);
        
        Debug.DrawRay(attackPoint.position, direction * hit.distance, Color.yellow);
        if(hit.collider != null && attackTimer <= 0){
            attackTimer = attackCooldown;
            var player = hit.collider.gameObject.GetComponent<PlayerHealth>();
            player.currentHealth -=  attackDamage - (int) hit.distance ;

            if(hit.distance >= attackRange - 0.2f){
                player.currentHealth -= attackDamage * 80/100;
                print("player got hit for "+ attackDamage * 80/100);
            }
            if(hit.distance >= attackRange * 0.5f){
                player.currentHealth -= attackDamage * 90/100;
                print("player got hit for "+ attackDamage * 90/100);
            }
            if(hit.distance < attackRange * 0.5f){
                player.currentHealth -= attackDamage;
                print("player got hit for "+ attackDamage);
            }
            player.ResetTaggedTimer();
            if(enemyName == EnemyName.WOLF){
                ChangeAnimation(wolfAttack_parameter);
            }
            if(enemyName == EnemyName.WOLF_MINIBOSS){
                ChangeAnimation(wolfMiniBossAttack_parameter);
            }
            attackTimer = attackCooldown;
            // print(hit.distance);
        }
    }

    public void ChangeAnimation(string newAnimation){
        if(currentAnimation == newAnimation) return;
        GetComponent<Animator>().Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
