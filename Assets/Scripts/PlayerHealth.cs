using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [Header("Health Status")]
    [SerializeField] int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
