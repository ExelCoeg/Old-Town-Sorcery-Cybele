using Unity.VisualScripting;
using UnityEngine;

public class GateScript : MonoBehaviour,IDamagable
{
    [SerializeField] float currentHealth;

    private void Update() {
        if(currentHealth<=0){
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
    }
}
