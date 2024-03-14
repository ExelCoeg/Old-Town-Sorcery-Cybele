
using UnityEngine;

public class TreeHealth : MonoBehaviour, IDamagable
{
    public float currentHealth;
    public float maxHealth;
    public bool isAlive = true;

    [SerializeField] GameObject[] fruits;
    private void Start() {
        currentHealth = maxHealth;
    }
    private void Update() {
        if(currentHealth<= 0 && isAlive){
            //add sound effect
            //instantiate blaze fruit or citro fruit
            Instantiate(fruits[Random.Range(0,fruits.Length)],transform.position,Quaternion.identity);
            isAlive = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;


        }
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
    }
}
