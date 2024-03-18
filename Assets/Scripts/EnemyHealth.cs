using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(currentHealth <= 0.1)
        {
            if(gameObject.name == "Wolf Boss"){
                WaveManager.instance.Win();
                
            }
            WaveManager.instance.enemySpawned.Remove(gameObject);
            Destroy(gameObject,0.5f);
            //death animation
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if(damageAmount < GetComponent<EnemyDefense>().currentDefense){
            damageAmount = 0;
        }
        currentHealth -= damageAmount - GetComponent<EnemyDefense>().currentDefense;
    }
    // private void OnDestroy() {
    //     WaveManager.instance.enemySpawned.Remove(gameObject);
    // }
}
