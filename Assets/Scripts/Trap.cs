
using UnityEngine;

public class Trap : MonoBehaviour
{
    public LayerMask enemyLayer;
    public bool isActivated = false;
    private void Update() {
        
        if(isActivated){
            
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,2f,enemyLayer);
            foreach(Collider2D hit in hits){
                hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
            }
            ParticleSystem explode = GetComponentInChildren<ParticleSystem>();
            if(!explode.isPlaying) explode.Play();
            if(!explode.IsAlive()) gameObject.SetActive(false);
            isActivated = false;
        }
    }
    
}

