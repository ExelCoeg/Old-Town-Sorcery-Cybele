using UnityEngine;
public class Well : MonoBehaviour, IInteractable {
    public float cooldown;
    
    [SerializeField] GameObject holyWater;

    [SerializeField] GameObject wellCooldownUI;
    private void Update() {
        if(cooldown >= 0){
            cooldown -= Time.deltaTime;
            wellCooldownUI.SetActive(true);
        }
        else{
            wellCooldownUI.SetActive(false);
        }
    }
    public void Interact(){
        if(cooldown <= 0){
            Instantiate(holyWater, transform.position, Quaternion.identity);
            cooldown = 1f;
        }       
    }


}