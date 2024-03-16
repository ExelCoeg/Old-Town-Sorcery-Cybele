
using UnityEngine;

public class Gate : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject craftingMenu;
    public float detectRadius;
    // Update is called once per frame
    void Update()
    {
        
        Collider2D player = Physics2D.OverlapCircle(transform.position, detectRadius,playerLayer);  
        if(player != null){
            // print("crafting menu on");
            craftingMenu.SetActive(true);
        }         
        else{
            // print("crafting menu off");
            craftingMenu.SetActive(false);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
