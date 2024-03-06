

using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    float timer;
    void Update()
    {
        if(WaveManager.instance.enemyToSpawn.Count > 0){

            timer +=Time.deltaTime;
            if(timer >= WaveManager.instance.spawnDelay){
                WaveManager.Enemy enemy = WaveManager.instance.enemyToSpawn[Random.Range(0,WaveManager.instance.enemyToSpawn.Count-1)];
                Instantiate(enemy.enemyGameObject, transform.position, Quaternion.identity);
                WaveManager.instance.enemyToSpawn.Remove(enemy);
                timer = 0;
            }
        }
    }



    
}
