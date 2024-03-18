using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int regenAmount;
    [SerializeField] Slider healthSlider;

    float taggedTimer;
    public float taggedUntilRegenTime = 2f;
    float regenTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {   
        if(taggedTimer >= 0)
        {
            taggedTimer -= Time.deltaTime;
        }
        if(currentHealth < maxHealth)
        {
            if(taggedTimer <= 0)
            {
                regenTimer -= Time.deltaTime;
                if(regenTimer <= 0)
                {
                    IncreaseHealth();
                    regenTimer = 1;
                }
            }
            else
            {
                regenTimer = 1;
            }
        }
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            WaveManager.instance.Lose();
        }
    }
    void IncreaseHealth(){
        currentHealth += regenAmount;
    }

    public void ResetTaggedTimer(){
        taggedTimer = taggedUntilRegenTime;
    }
    public void TakeDamage(float amount){
        currentHealth -= (int)(amount - GetComponent<PlayerDefense>().currentDefense);
    }   

}
