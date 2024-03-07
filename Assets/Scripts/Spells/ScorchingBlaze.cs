using UnityEngine;

public class ScorchingBlaze : MonoBehaviour
{
    LayerMask enemyLayer;
    float percentageAmount;
    ParticleSystem effect;

    private void Start() {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }
    public void init(float percentageAmount, ParticleSystem effect){
        this.percentageAmount = percentageAmount;
        this.effect = effect;

    }
    private void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero,enemyLayer);
        if(hit.collider != null){
            print("mouse is on " + hit.collider.gameObject.name);
            var enemy = hit.collider.gameObject.GetComponent<EnemyHealth>();
            ParticleSystem scorchingBlazeEffect = Instantiate(effect, enemy.transform.position, Quaternion.identity);
            scorchingBlazeEffect.transform.SetParent(hit.collider.gameObject.transform);
            scorchingBlazeEffect.Play();
            enemy.currentHealth -= percentageAmount/100 * enemy.currentHealth ;
            scorchingBlazeEffect.GetComponent<DestroySelf>().Destroy(1);
            Destroy(this,2);
        }
        
    }
    
    
}