
using UnityEngine;

public class Gate : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject craftingMenu;
   
    // Update is called once per frame
    void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, 1f,playerLayer);  
        if(player != null){
            print("crafting menu on");
            craftingMenu.SetActive(true);
        }         
        else{
            print("crafting menu off");
            craftingMenu.SetActive(false);
        }
    }
}
