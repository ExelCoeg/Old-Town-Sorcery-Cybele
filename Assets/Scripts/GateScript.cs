using Unity.VisualScripting;
using UnityEngine;

public class GateScript : MonoBehaviour,IDamagable
{
    [SerializeField] float currentHealth;
    [SerializeField] GameObject leftGate;
    [SerializeField] GameObject rightGate;
    [SerializeField] Sprite leftGateOpen;
    [SerializeField] Sprite rightGateOpen;
    bool open;
    bool soundPlayed;
    private void Update() {
        
        if(currentHealth<=0  && !open){
            GetComponent<BoxCollider2D>().enabled = false;
            leftGate.GetComponent<SpriteRenderer>().sprite = leftGateOpen;
            rightGate.GetComponent<SpriteRenderer>().sprite = rightGateOpen;
            leftGate.transform.position = new Vector3(7.55f,-27.26f,0);
            rightGate.transform.position = new Vector3(9.75f,-27.26f,0);
            open = true;
            if(!soundPlayed ){
                AudioManager.instance.PlaySFX("gate_destroyed");
                soundPlayed = true;
            }
        }
    }
    public void TakeDamage(float amount){
        currentHealth -= amount;
    }
   
}
