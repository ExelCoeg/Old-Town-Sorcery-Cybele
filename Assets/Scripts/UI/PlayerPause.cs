using UnityEngine;
using UnityEngine.Audio;
public class PlayerPause : MonoBehaviour {

    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public bool pause= false;
    
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.Escape)  && !pause){
            pauseMenu.SetActive(true);
            pause = true;
            Time.timeScale= 0;
            audioMixer.SetFloat("music",-100);
        }
    }
}