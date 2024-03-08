using System.Collections.Generic;
using UnityEngine;

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
        nightTime = enemyToSpawn.Count * (spawnDelay + 5);
        nightCountDown = nightTime;
    }
    private void Update() {
        nightCountDown-= Time.deltaTime;
        if(nightCountDown <= 0){
            nightCountDown = nightTime; 
            GenerateWave();
        }
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