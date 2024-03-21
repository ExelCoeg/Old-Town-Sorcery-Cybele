
using UnityEngine;

public class Trap : MonoBehaviour
{
    public LayerMask enemyLayer;
    ParticleSystem explode;
    bool isPlaying = false;
    private void Awake() {
        explode = GetComponentInChildren<ParticleSystem>();
    }
    private void Update() {
        if(isPlaying){
            GetComponent<SpriteRenderer>().enabled = false;
            if(explode.isStopped){
                gameObject.SetActive(false);
            }
        }
    }
    public void Explode(){
        if(!isPlaying){
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,2f,enemyLayer);
            foreach(Collider2D hit in hits){
                hit.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
            }
            
            AudioManager.instance.PlaySFX("trap_explode");
            isPlaying = true;
        }
    }
    
}

