
using UnityEngine;

public class BuffTimer : MonoBehaviour
{
    float timer;
    float effectTime;
    PlayerCombat player;
    ConsummablePotionName potionName;
    public void init(float effectTime, ConsummablePotionName potionName)
    {
        this.effectTime = effectTime;
        this.potionName= potionName;
    }
    private void Awake()
    {
        player = GetComponent<PlayerCombat>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= effectTime)
        {
            if(potionName == ConsummablePotionName.ATK_BUFF){
                player.attackDamage = player.maxAttackDamage;
            }
            // check buff lain kalau ada

            Destroy(this);
        }
    }

}   
