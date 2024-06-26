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
    [Header("Trap")]
    public GameObject[] traps;
    private float timer;
    public float timerForAM;
    public float noonTime;
    public bool noon = true;

    [Header("Texts")]
    public TextMeshProUGUI dayText;
    public GameObject noonTimer;
    // public TextMeshProUGUI timeText;
    [Header("UI")]
    public GameObject WinUI;
    public GameObject LoseUI;

    [Header("World Light")]
    public Light2D worldLight;
    
    [Header("Health Bar & Mana Bar")]
    public GameObject healthBar;
    public GameObject manaBar;
    
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
        if(!GameManager.instance.pause){
            if(noon){
                dayText.text = "Noon";
                healthBar.SetActive(false);
                manaBar.SetActive(false);
            } 
            else {
                dayText.text = "Night";
                healthBar.SetActive(true);
                manaBar.SetActive(true);
            }
            if(noon) {
                timer -= Time.deltaTime;
                timerForAM = timer; 
                noonTimer.GetComponent<TextMeshProUGUI>().text = ((int) timer).ToString();
                if(timer<=0) {
                    AudioManager.instance.PlayMusic("night");
                    foreach(GameObject trap in traps) {
                        trap.SetActive(true);
                        trap.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    worldLight.GetComponent<Animator>().SetTrigger("switch");
                    noon = !noon;
                    GenerateWave();
                    noonTimer.SetActive(false);
                }   
            }
            if(!noon & enemySpawned.Count <= 0 && waveValue <= 0){

                AudioManager.instance.PlayMusic("noon");
                noonTimer.SetActive(true);
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
        

            if(enemy.value > waveValue){
                spawnTimer = 0.1f;
                break;
            }
            
            waveValue -= enemy.value;
            
            GameObject enemyClone = Instantiate(enemy.enemyGameObject,spawnPoint.position,Quaternion.identity);
            enemySpawned.Add(enemyClone);   
            enemyClone.GetComponent<EnemyMovement>().SetTargetPosition(targetPos);
            
            spawnTimer = spawnDelay;
        }
     
    }
    public void Win(){
        Time.timeScale = 0;
        AudioManager.instance.audioMixer.SetFloat("music",-100);    
        GameManager.instance.pause = true;
        WinUI.SetActive(true);

    }
    public void Lose(){
        Time.timeScale = 0;
        AudioManager.instance.audioMixer.SetFloat("music",-100);    
        GameManager.instance.pause = true;
        LoseUI.SetActive(true);
    }
    [System.Serializable]
    public class Enemy{
        public GameObject enemyGameObject;
        public int value;
    }
}