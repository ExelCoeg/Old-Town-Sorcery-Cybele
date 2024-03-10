using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaveManager : MonoBehaviour{


    public static WaveManager instance;
    public bool coroutineControl;
    public List<Enemy> enemyList = new List<Enemy>();
    public List<GameObject> enemyToSpawn = new List<GameObject>();
    public List<GameObject> enemySpawned = new List<GameObject>();
    public float spawnDelay;
    int currentNight;
    private int waveValue;
    

    private float timer;
    public float noonTime;
    bool noon = true;

    public Light2D worldLight;
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    private void Start() {
        timer = noonTime;
    }
    private void Update() { 
        if(noon) {
            timer -= Time.deltaTime;
            if(timer<=0) {
                worldLight.GetComponent<Animator>().SetTrigger("switch");
                noon = !noon;
                GenerateWave();
            }   
        }
        
        if(enemyToSpawn.Count <= 0 && !noon & enemySpawned.Count <= 0){
            worldLight.GetComponent<Animator>().SetTrigger("switch");
            noon = !noon;
            timer = noonTime;
        }   
    }
    public void GenerateWave(){
        currentNight++;
        waveValue = currentNight * 10; 
        GenerateEnemies();
        coroutineControl = true;
    }
    public void GenerateEnemies(){
        List<GameObject> temp = new List<GameObject>();
        while(waveValue >= 0){
            Enemy enemy = enemyList[Random.Range(0,enemyList.Count-1)];
            
            temp.Add(enemy.enemyGameObject);
            waveValue -= enemy.value;
        }
        enemyToSpawn = temp;
    }

    [System.Serializable]
    public class Enemy{
        public GameObject enemyGameObject;
        public int value;
    }
}