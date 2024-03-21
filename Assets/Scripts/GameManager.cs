using UnityEngine;
public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool pause = false;
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Update() {
        if(pause){
            Time.timeScale =0;
        }
        else{
            Time.timeScale = 1f;
        }
    }
}