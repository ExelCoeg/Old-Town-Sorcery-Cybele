using UnityEngine;
public class DestroySelf : MonoBehaviour
{

    public void Destroy(float time){
        GetComponent<Animator>().SetTrigger("switch");
        Destroy(gameObject,time);
    }

}
