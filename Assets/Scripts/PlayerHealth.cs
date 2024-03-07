using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    [SerializeField] Slider healthSlider;

    public float taggedTimer;
    public float taggedUntilRegenTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {   
        if(taggedTimer >= 0) taggedTimer -= Time.deltaTime;
        if(currentHealth < maxHealth && taggedUntilRegenTime <= 0) Invoke("IncreaseHealth", 1);
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        // if (currentHealth <= 0)
        // {
        //     Destroy(gameObject);
        // }
    }
    
    void IncreaseHealth(){
        currentHealth += 10;
    }
}
