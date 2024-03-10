using UnityEngine;

public enum EnemyName{
    WOLF,
    WOLF_MINIBOSS,
    WOLF_BOSS
}
public class EnemyMovement : MonoBehaviour
{
    public EnemyName enemyName;
    public float speed;
    
    private float distance;

    [SerializeField] float detectRadius = 2f;
    [SerializeField] Transform targetPos;
    public LayerMask playerLayer;

    /*---------- animation variables ---------*/

    private string wolfWalk_parameter = "wolf_walk";
    private string wolfMiniBossWalk_parameter = "wolf_mini_boss_walk";

    private string wolfBossWalk_parameter = "wolf_boss_walk";

    // private string wolfIdle_parameter = "wolf_idle";
    private string currentAnimation;


    void FixedUpdate()
    {
        
        Collider2D playerDetect = Physics2D.OverlapCircle(transform.position, detectRadius, playerLayer);
        if(playerDetect){
            distance = playerDetect.gameObject.transform.position.x - transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, playerDetect.gameObject.transform.position, speed * Time.fixedDeltaTime);
        }
        else if(playerDetect == null) {
            distance = targetPos.position.x - transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.fixedDeltaTime);
        }
        if(enemyName == EnemyName.WOLF){
            ChangeAnimation(wolfWalk_parameter);
        }
        if(enemyName == EnemyName.WOLF_MINIBOSS){
            ChangeAnimation(wolfMiniBossWalk_parameter);
        }
        if(enemyName == EnemyName.WOLF_BOSS){
            ChangeAnimation(wolfBossWalk_parameter);
        }
        
        transform.eulerAngles = distance < 0 ? Vector2.up * -180: Vector2.zero; 
       
    }

    public void ChangeAnimation(string newAnimation){
        if(currentAnimation == newAnimation) return;
        GetComponent<Animator>().Play(newAnimation);
        currentAnimation = newAnimation;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
    public void SetTargetPosition(Transform targetPos){
        this.targetPos = targetPos;
    }
}
