
using UnityEngine;

public class ConsummablePotion : MonoBehaviour, IConsummable
{
    public float percentageAmount;
    public float PercentageAmount {set {percentageAmount = value;}}
    public ConsummablePotionName potionName;
    public ConsummablePotionName PotionName { get { return potionName; } }


    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (potionName == ConsummablePotionName.HEAL)
        {
            player.GetComponent<PlayerHealth>().currentHealth +=  (int) (percentageAmount / 100.0 *  player.GetComponent<PlayerHealth>().maxHealth);
            
        }
        if(potionName == ConsummablePotionName.ATK_BUFF)
        {
            player.GetComponent<PlayerCombat>().attackDamage += percentageAmount/100 * player.GetComponent<PlayerCombat>().attackDamage;
            var buffATKScript = player.AddComponent<BuffTimer>();
            buffATKScript.init(5,potionName);
        }
        
    }
}
