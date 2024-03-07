using UnityEngine;
public class DestroySelf : MonoBehaviour
{
    public void Destroy(float time){
        Destroy(gameObject,time);
    }
}
