
using UnityEngine;

public class TreeHealth : MonoBehaviour, IDamagable
{
    float currentHealth;
    [SerializeField] float maxHealth;

    [SerializeField] GameObject[] fruits;
    private void Start() {
        currentHealth = maxHealth;
    }
    private void Update() {
        if(currentHealth<= 0){
            //add sound effect
            //instantiate blaze fruit or citro fruit
            Instantiate(fruits[Random.Range(0,fruits.Length)],transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
    }
}
