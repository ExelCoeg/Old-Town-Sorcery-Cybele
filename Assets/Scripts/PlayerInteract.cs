using UnityEngine;
using TMPro;
public class PlayerInteract : MonoBehaviour {

    public LayerMask interactLayer;
    private void Update() {
        Collider2D[] interacts = Physics2D.OverlapCircleAll(transform.position, 2f,interactLayer);
        foreach(Collider2D interact in interacts){
            if(interact.TryGetComponent<IInteractable>(out IInteractable interactable)){
                
                if(Input.GetKeyDown(KeyCode.F)) interactable.Interact(); 
            }
        } 
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,2f);
    }
}