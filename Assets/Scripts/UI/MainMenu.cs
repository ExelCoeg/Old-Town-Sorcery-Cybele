
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        GameManager.instance.pause = false;
    }
}
