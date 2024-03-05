
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float maxHealth;
    public float currentHealth;

    float damage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }
}
