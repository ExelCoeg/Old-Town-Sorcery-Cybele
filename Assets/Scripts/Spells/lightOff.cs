
using UnityEngine;

public class lightOff : MonoBehaviour
{
    public GameObject fireballLight;

    void Update()
    {
        if(GetComponent<SpriteRenderer>().sprite == null) Invoke("TriggerOff", 5);
        
    }


    void TriggerOff(){
        fireballLight.GetComponent<Animator>().SetTrigger("switch");
    }
}
