using Unity.VisualScripting;
using UnityEngine;

public class Bush : MonoBehaviour {
    float currentHealth;
    [SerializeField] GameObject leisureBerry;
    [SerializeField] float maxHealth;
    private void Start() {
        currentHealth = maxHealth;
    }
    private void Update() {
        if(currentHealth<= 0){
            // add sound effect
            //instantiate leisure berry
            Instantiate(leisureBerry,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
    }
}