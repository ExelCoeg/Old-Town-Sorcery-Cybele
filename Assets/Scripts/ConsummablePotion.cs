using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsummablePotion : MonoBehaviour, IConsummable
{
    public ConsummablePotionName potionName;
    public ConsummablePotionName PotionName { get { return potionName; } }
    public float percentageAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Use();
        }
    }
    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (potionName == ConsummablePotionName.HEAL)
        {
            player.GetComponent<PlayerHealth>().currentHealth +=  (int) (percentageAmount / 100) * player.GetComponent<PlayerHealth>().currentHealth;
        }
        if(potionName == ConsummablePotionName.ATK_BUFF)
        {
            var buffATKScript = player.AddComponent<BuffPotion>();
            buffATKScript.init(20);
        }
    }
}
