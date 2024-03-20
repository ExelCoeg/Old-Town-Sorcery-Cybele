
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    public List<Transform> spawnPoints = new List<Transform>();
    private void Update() {
        if(!WaveManager.instance.noon){
            WaveManager.instance.SpawnEnemy(spawnPoints[Random.Range(0,spawnPoints.Count)],targetPos);
        }
       
    }
   
   
}
