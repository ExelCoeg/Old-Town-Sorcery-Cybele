using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaveManager : MonoBehaviour{


    public static WaveManager instance;
    public bool coroutineControl;
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> enemyToSpawn = new List<Enemy>();
    public List<GameObject> enemySpawned = new List<GameObject>();
    public float spawnDelay;
    int currentNight;
    
    private float nightCountDown;
    public float nightTime;
    private float noonCountDown;
    public float noonTime;

    public Light2D worldLight;

    
    private int waveValue;
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    private void Start() {
        GenerateWave();
        // nightTime = enemyToSpawn.Count * spawnDelay;
        nightTime = 10;
        nightCountDown = nightTime;
        noonCountDown = noonTime;
    }
    private void Update() {
        //intensity 0.7
        noonCountDown -= Time.deltaTime;
        
        print(noonCountDown);
        if(noonCountDown <= 0){
            worldLight.GetComponent<Animator>().SetTrigger("switch");

            noonCountDown = nightTime;

            // worldLight.GetComponent<Animator>().Play("daytonight");
            // nightCountDown = nightTime; 
            // GenerateWave();
        }
        // nightCountDown-= Time.deltaTime;
        // if(enemySpawned.Count == 0 || nightCountDown <= 0){
        // }
        
        
        
    }
    public void GenerateWave(){

        currentNight++;
        waveValue = currentNight * 20; 
        GenerateEnemies();
        coroutineControl = true;
    }
    public void GenerateEnemies(){
        List<Enemy> temp = new List<Enemy>();
        while(waveValue >= 0){
            Enemy enemy = enemyList[Random.Range(0,enemyList.Count-1)];
            temp.Add(enemy);
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