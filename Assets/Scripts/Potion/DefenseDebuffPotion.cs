using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDebuffPotion : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            print("Enemy defense decrease by 2");
            //collision.gameObject.GetComponent<EnemyDefense>().currentDefense -= 2;
        }
    }
}
