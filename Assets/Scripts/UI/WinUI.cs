
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
{
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Retry(){
        SceneManager.LoadScene(1);
    }
}
