
using UnityEngine;

public class Gate : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject craftingMenu;
    Vector2 detectPos;
    public float detectRadius;
    // Update is called once per frame
    void Update()
    {
        detectPos = new Vector2(transform.position.x,transform.position.y + 5);
        Collider2D player = Physics2D.OverlapCircle(detectPos, detectRadius,playerLayer);  
        if(player != null){
            print("crafting menu on");
            craftingMenu.SetActive(true);
        }         
        else{
            print("crafting menu off");
            craftingMenu.SetActive(false);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(detectPos, detectRadius);
    }
}
