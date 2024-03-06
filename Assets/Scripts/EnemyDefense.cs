using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefense : MonoBehaviour
{
    public float maxDefense;
    public float currentDefense;

    // Start is called before the first frame update
    void Start()
    {        
        currentDefense = maxDefense;
    }

    
}
