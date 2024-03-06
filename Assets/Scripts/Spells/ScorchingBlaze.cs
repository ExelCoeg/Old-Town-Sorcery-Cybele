using UnityEngine;

public class ScorchingBlaze : MonoBehaviour
{
    public LayerMask enemyLayer;
    private void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero,enemyLayer);
        if(hit.collider != null){
            print("mouse is on " + hit.collider.gameObject.name);
            hit.collider.gameObject.GetComponent<EnemyHealth>().currentHealth -= 10;
            Destroy(this);
        }
        
    }
}