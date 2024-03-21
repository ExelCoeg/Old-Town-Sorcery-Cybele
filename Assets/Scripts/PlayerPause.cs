using UnityEngine;
using UnityEngine.Audio;
public class PlayerPause : MonoBehaviour {
    public GameObject pauseMenu;
     public AudioMixer audioMixer;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.pause){
            pauseMenu.SetActive(true);
            audioMixer.SetFloat("music",-100);
            GameManager.instance.pause = true;
        }
    }
}