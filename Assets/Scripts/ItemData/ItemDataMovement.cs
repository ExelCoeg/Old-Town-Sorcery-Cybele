using UnityEngine;

public class ItemDataMovement : MonoBehaviour {
    Vector3 targetPos;
    float speed = 1.5f;
    [SerializeField] float destroyTime;
    private void Start() {
        targetPos = new Vector3(Random.Range(-10,10), Random.Range(-10,10),0);
        // print(targetPos);
    }
    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        Destroy(gameObject,destroyTime);        
    }
}