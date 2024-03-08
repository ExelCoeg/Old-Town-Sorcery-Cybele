using UnityEngine;

public class ScorchingBlaze : MonoBehaviour
{
    LayerMask enemyLayer;
    float percentageAmount;
    ParticleSystem effect;
    bool isPlaying;
    Vector2 mousePos   ; 
    RaycastHit2D hit;
    private void Start() {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }
    public void init(float percentageAmount, ParticleSystem effect){
        this.percentageAmount = percentageAmount;
        this.effect = effect;
    }
    private void Update() {
        if(!isPlaying) {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos,Vector2.zero,enemyLayer);
        }
        if(hit.collider != null){
            var enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
            ParticleSystem scorchingBlazeEffect = Instantiate(effect, enemy.transform.position, Quaternion.identity);
            if(scorchingBlazeEffect != null){
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                scorchingBlazeEffect.transform.SetParent(hit.collider.gameObject.transform);
                if(!isPlaying){
                    scorchingBlazeEffect.Play();
                }
                isPlaying = true;
                enemy.currentHealth -= percentageAmount/100f * enemy.currentHealth  +  0.25f * player.GetComponent<PlayerCombat>().attackDamage;
                scorchingBlazeEffect.GetComponent<DestroySelf>().Destroy(1);
            }
            Destroy(this);
        }
        else{
            Destroy(this);
        }
    }
}