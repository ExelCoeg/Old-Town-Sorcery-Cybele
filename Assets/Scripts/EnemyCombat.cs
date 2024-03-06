using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public int attackDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("colliding with player");
            collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= attackDamage;
             
         }
    }
}
