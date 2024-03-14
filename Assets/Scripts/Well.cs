using Unity.Mathematics;
using UnityEngine;

public class Well : MonoBehaviour, IInteractable {
    float cooldown;
    [SerializeField] GameObject holyWater;
    private void Update() {
        if(cooldown >= 0){
            cooldown -= Time.deltaTime;
        }
    }
    public void Interact(){
        if(cooldown <= 0){
            Instantiate(holyWater, transform.position, Quaternion.identity);
            cooldown = 1f;
        }       
    }
}