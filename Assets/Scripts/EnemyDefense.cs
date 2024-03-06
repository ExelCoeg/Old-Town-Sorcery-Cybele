using UnityEngine;
public class EnemyDefense : MonoBehaviour
{
    public float maxDefense;
    public float currentDefense;
    void Start()
    {        
        currentDefense = maxDefense;
    }
}
