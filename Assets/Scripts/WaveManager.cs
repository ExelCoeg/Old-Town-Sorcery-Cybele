using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaveManager : MonoBehaviour{
    public static WaveManager instance;
    [Header("Enemy Lists")]
    public List<Enemy> enemyList = new List<Enemy>();
    // public List<Enemy> enemyToSpawn = new List<Enemy>();
    public List<GameObject> enemySpawned = new List<GameObject>();
    public int multiplier;
    [Header("Wave Attributes")]
    public float spawnDelay;
    private float spawnTimer;
    int currentNight;
    private int waveValue;


    private float timer;
    public float noonTime;
    public bool noon = true;

    [Header("Texts")]
    public TextMeshProUGUI dayText;
    // public TextMeshProUGUI timeText;
    [Header("UI")]
    public GameObject WinUI;
    public GameObject LoseUI;

    [Header("World Light")]
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
        if(noon) dayText.text = "Noon";
        else dayText.text = "Night";
        
        if(noon) {
            timer -= Time.deltaTime;
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
            GameObject[] resourceObjects = GameObject.FindGameObjectsWithTag("Tree");
            foreach(GameObject resourceObject in resourceObjects){
                if(!resourceObject.GetComponent<ResourceObjectHealth>().isAlive){
                    resourceObject.GetComponent<ResourceObjectHealth>().currentHealth = resourceObject.GetComponent<ResourceObjectHealth>().maxHealth;
                    resourceObject.GetComponent<ResourceObjectHealth>().isAlive = true;
                    resourceObject.GetComponent<SpriteRenderer>().enabled = true;
                    resourceObject.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }   
        
    }
    public void GenerateWave(){
        currentNight++;
        waveValue = currentNight * multiplier; 
        
        spawnTimer = spawnDelay;
      
    }
    public void SpawnEnemy(Transform spawnPoint, Transform targetPos){
        if(waveValue >= 0 ){
            spawnTimer -= Time.deltaTime;
        }
        while(waveValue >= 0 && spawnTimer <= 0){
            Enemy enemy = enemyList[Random.Range(0,enemyList.Count)];
            if(waveValue < multiplier && enemySpawned.Count ==0){
                waveValue = 0;
                break;
            }
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
    public void Win(){
        Time.timeScale = 0;
        //win ui ->go to main menu
        WinUI.SetActive(true);

    }
    public void Lose(){
        Time.timeScale = 0;
        LoseUI.SetActive(true);
        //lose ui -> go to main menu or retry
    }
    [System.Serializable]
    public class Enemy{
        public GameObject enemyGameObject;
        public int value;
    }
}