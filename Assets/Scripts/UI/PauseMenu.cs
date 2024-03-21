
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
        GameManager.instance.pause = false;
        gameObject.SetActive(false);
        Time.timeScale =1f;
    }
}
