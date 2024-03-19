
using UnityEngine;
public class EnemyCombat : MonoBehaviour
{
    public EnemyName enemyName;
    [Header("Attack Attributes")]
    public float attackDamage;
    float attackTimer;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackRange = 1.5f;
    
    public Transform attackPoint;

    /*--------Layers ------------*/
    [Header("Layers")]
    public LayerMask playerLayer;
    public LayerMask damagableLayer;
    /*--------animation variable ------------*/
    private string wolfAttack_parameter = "wolf_attack";
    private string wolfMiniBossAttack_parameter = "wolf_mini_boss_attack";
    private string wolfBossAttack_parameter = "wolf_boss_attack";
    private string currentAnimation;
    
    private void Start() {
        attackTimer = attackCooldown + 2;
        enemyName = GetComponent<EnemyMovement>().enemyName;
    }
    private void Update() {
       
        attackTimer -= Time.deltaTime;
        Vector2 direction = transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
        
        Collider2D hitDamagable = Physics2D.OverlapCircle(attackPoint.position, 0.5f, damagableLayer);
        if(hitDamagable && attackTimer<= 0){
            print("test");
            IDamagable damagable = hitDamagable.gameObject.GetComponent<IDamagable>();
            damagable.TakeDamage(attackDamage);
            EnemyAnimation();
            
            attackTimer = attackCooldown;
        }
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange, playerLayer);
        if(hit.collider != null && attackTimer <= 0){
            var player = hit.collider.gameObject.GetComponent<PlayerHealth>();
            
            if(hit.distance >= attackRange - 0.2f){
                player.TakeDamage(attackDamage *  80f/100 - (float) hit.distance);
            }
            if(hit.distance >= attackRange * 0.5f){
                player.TakeDamage(attackDamage *  90f/100 - (float) hit.distance);
            }
            if(hit.distance < attackRange * 0.5f){
                player.TakeDamage(attackDamage - (float) hit.distance);
            }
            EnemyAnimation();
            player.ResetTaggedTimer();
            attackTimer = attackCooldown;
        }
        
    }


    public void EnemyAnimation(){
        if(enemyName == EnemyName.WOLF){
            GetComponent<Animator>().Play(wolfAttack_parameter);
        }
        if(enemyName == EnemyName.WOLF_MINIBOSS){
            GetComponent<Animator>().Play(wolfMiniBossAttack_parameter);
        }
        if(enemyName == EnemyName.WOLF_BOSS){
            GetComponent<Animator>().Play(wolfBossAttack_parameter);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackPoint.position, 2f);
    }
    
}
