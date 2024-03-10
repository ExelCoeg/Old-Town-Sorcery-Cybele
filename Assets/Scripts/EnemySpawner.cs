
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    float spawnTimer;
    public List<Transform> spawnPoints = new List<Transform>();
    private void Update() {
        if(!WaveManager.instance.noon){
            WaveManager.instance.SpawnEnemy(spawnPoints[Random.Range(0,spawnPoints.Count)],targetPos);
        }
        // if(WaveManager.instance.coroutineControl){
        //     StartCoroutine(SpawnEnemy());
        // }
    }
    // IEnumerator SpawnEnemy(){
    //     WaveManager.instance.coroutineControl = false;
    //     WaitForSeconds spawnDelay = new WaitForSeconds(WaveManager.instance.spawnDelay);
    //     int spawn = 0;
    //     while(WaveManager.instance.enemyToSpawn.Count > 0){
    //         spawn++;
            
    //         WaveManager.Enemy enemy = WaveManager.instance.enemyToSpawn[Random.Range(0,WaveManager.instance.enemyToSpawn.Count-1)];
    //         if(enemy != null){
    //             GameObject enemyClone =  Instantiate(enemy.enemyGameObject, transform.position, Quaternion.identity);
    //             enemyClone.GetComponent<EnemyMovement>().SetTargetPosition(targetPos);
    //             WaveManager.instance.enemySpawned.Add(enemyClone);
    //             WaveManager.instance.enemyToSpawn.Remove(enemy);
    //             yield return spawnDelay;
    //         }
    //     }
    // }

   
}
