
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
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damageAmount)
    {
        if(damageAmount < GetComponent<EnemyDefense>().currentDefense){
            damageAmount = 0;
        }
        currentHealth -= damageAmount - GetComponent<EnemyDefense>().currentDefense;
    }
}
