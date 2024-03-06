
using Unity.VisualScripting;
using UnityEngine;

public class DefenseDebuffPotion : MonoBehaviour
{
    [SerializeField] float aoeRadius = 1f;
    [SerializeField] int decreaseAmount;
    [SerializeField] float disappearTime;
    bool gizmo;

    public void init(float aoeRadius, int decreaseAmount, float disappearTime)
    {
        this.aoeRadius = aoeRadius;
        this.decreaseAmount = decreaseAmount;
        this.disappearTime = disappearTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gizmo = true;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, aoeRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.TryGetComponent<EnemyDefense>(out EnemyDefense enemyDefense))
                {
                    print("enemy defense is decreased by " + decreaseAmount);
                    enemyDefense.currentDefense -=  5;
                }
            }
            Destroy(gameObject, disappearTime);
        }
    }
    private void OnDrawGizmos()
    {
        if (gizmo) Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }

}
