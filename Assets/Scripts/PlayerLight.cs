
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    public GameObject playerLight;
    bool on = false;

    // Update is called once per frame
    void Update()
    {
        if(WaveManager.instance.noon == false && !on){
            print("switching on");
            on = !on;
            playerLight.GetComponent<Animator>().SetTrigger("switch");
        }
        if(WaveManager.instance.noon == true && on){
            print("switching off");
            on = !on;
            playerLight.GetComponent<Animator>().SetTrigger("switch");
        }
       
            
    }
}
