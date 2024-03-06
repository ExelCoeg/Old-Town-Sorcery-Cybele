using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    [SerializeField] Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth) currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        // if (currentHealth <= 0)
        // {
        //     Destroy(gameObject);
        // }
    }
}
