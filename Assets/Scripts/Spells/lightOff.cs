
using UnityEngine;

public class LightOff : MonoBehaviour
{
    public GameObject fireballLight;
    public Vector2 targetPos;
  
    private void Start() {
        fireballLight.transform.eulerAngles = new Vector3(0,0,0);
    }
    void Update()
    {
        Invoke("Switch",4);
    }
    void Switch(){
        fireballLight.GetComponent<Animator>().SetTrigger("switch");
    }
}