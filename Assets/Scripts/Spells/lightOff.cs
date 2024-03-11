
using UnityEngine;

public class lightOff : MonoBehaviour
{
    public GameObject fireballLight;
    private void Start() {
        fireballLight.transform.eulerAngles = new Vector3(0,0,0);
    }
    void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite == null) {
            Invoke("TriggerOff", 5);
            fireballLight.transform.position = Vector2.MoveTowards(fireballLight.transform.position,//
            new Vector2(fireballLight.transform.position.x, fireballLight.transform.position.y + 1), 5 * Time.deltaTime);
        }
    }
    void TriggerOff(){
        fireballLight.GetComponent<Animator>().SetTrigger("switch");
    }
}