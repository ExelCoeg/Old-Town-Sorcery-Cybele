using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaveManager : MonoBehaviour{
    public static WaveManager instance;
    public List<Enemy> enemyList = new List<Enemy>();
    // public List<Enemy> enemyToSpawn = new List<Enemy>();
    public List<GameObject> enemySpawned = new List<GameObject>();
    public float spawnDelay;
    private float spawnTimer;
    int currentNight;
    private int waveValue;
    

    private float timer;
    public float noonTime;
    public bool noon = true;

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
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            
            foreach(GameObject tree in trees){
                if(!tree.GetComponent<TreeHealth>().isAlive ){
                    tree.GetComponent<TreeHealth>().currentHealth = tree.GetComponent<TreeHealth>().maxHealth;
                    tree.GetComponent<TreeHealth>().isAlive = true;
                    tree.GetComponent<SpriteRenderer>().enabled = true;
                    tree.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            
            if(timer<=0) {
                worldLight.GetComponent<Animator>().SetTrigger("switch");
                noon = !noon;
                GenerateWave();
            }   
        }
       
        
        if(!noon & enemySpawned.Count <= 0 && waveValue <= 0){
            worldLight.GetComponent<Animator>().SetTrigger("switch");
            noon = !noon;
            timer = noonTime;
        }   
        
    }
    public void GenerateWave(){
        currentNight++;
        waveValue = currentNight * 25; 
        
        spawnTimer = spawnDelay;
      
    }
    public void SpawnEnemy(Transform spawnPoint, Transform targetPos){
        if(waveValue >= 0 ){
            spawnTimer -= Time.deltaTime;
        }
        while(waveValue >= 0 && spawnTimer <= 0){
            Enemy enemy = enemyList[Random.Range(0,enemyList.Count)];
            if(enemy.value > waveValue){
                spawnTimer = 0.1f;
                break;
            }
            
            GameObject enemyClone = Instantiate(enemy.enemyGameObject,spawnPoint.position,Quaternion.identity);
            waveValue -= enemy.value;
            spawnTimer = spawnDelay;
            enemySpawned.Add(enemyClone);   
            enemyClone.GetComponent<EnemyMovement>().SetTargetPosition(targetPos);
        }
     
    }

    [System.Serializable]
    public class Enemy{
        public GameObject enemyGameObject;
        public int value;
    }
}