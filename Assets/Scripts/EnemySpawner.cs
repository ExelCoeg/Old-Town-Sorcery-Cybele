
using System.Collections;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    
    private void Update() {
        
        if(WaveManager.instance.coroutineControl){
            StartCoroutine(SpawnEnemy());
        }
    }
    IEnumerator SpawnEnemy(){
        WaveManager.instance.coroutineControl = false;
        print("on coroutine");
        WaitForSeconds spawnDelay = new WaitForSeconds(WaveManager.instance.spawnDelay);
        int spawn = 0;
        while(WaveManager.instance.enemyToSpawn.Count > 0){
            spawn++;
            print("spawn time: " + spawn);
            WaveManager.Enemy enemy = WaveManager.instance.enemyToSpawn[Random.Range(0,WaveManager.instance.enemyToSpawn.Count-1)];
            GameObject enemyClone =  Instantiate(enemy.enemyGameObject, transform.position, Quaternion.identity);
            WaveManager.instance.enemySpawned.Add(enemyClone);
            WaveManager.instance.enemyToSpawn.Remove(enemy);
            yield return spawnDelay;
        }
    }
}
