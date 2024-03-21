
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void UnPause(){
        GameObject player= GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerPause>().pause = false;
        Time.timeScale = 1;
        
        
        gameObject.SetActive(false);
    }
}
