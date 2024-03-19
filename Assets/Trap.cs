
using System.Transactions;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public LayerMask enemyLayer;
    bool isActivated;
    private void Update() {
        
        if(isActivated){
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,2f,enemyLayer);
            foreach(Collider2D hit in hits){
                hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) isActivated = true;
    }
}

