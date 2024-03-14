
using UnityEngine;
using TMPro;
public class Crafting : MonoBehaviour
{
    float timerOne;
    float timerTwo;
    float timerThree;
    
    float defenseDebuffPotionCraftTime;
    float buffATKPotionCraftTime;
    float healingPotionCraftTime;

    [SerializeField] GameObject defenseDebuffPotion;
    [SerializeField] GameObject buffATKPotion;
    [SerializeField] GameObject healingPotion;

   public ItemData blazeFruitData;
   public ItemData citroFruitData;
   public ItemData leisureBerryData;
   public ItemData holyWaterData;
    public Inventory inventory;
    public PlayerCombat playerCombat;

    // Update is called once per frame
    private void Start() {
        timerOne = defenseDebuffPotionCraftTime;
        timerTwo = buffATKPotionCraftTime;
        timerThree = healingPotionCraftTime;
    }
    void Update()
    {
        if(timerOne >= 0){
            timerOne -= Time.deltaTime;
            if(timerOne <= 0){
                //add potion to player potion inventory
                playerCombat.ownedPotions.Add(defenseDebuffPotion);
                inventory.Remove(leisureBerryData);
                inventory.Remove(leisureBerryData);
                inventory.Remove(holyWaterData);
            }
        }
        if(timerTwo>=0){
            timerTwo -= Time.deltaTime;
            if(timerTwo <= 0){
                //add potion to player potion inventory
                playerCombat.ownedPotions.Add(buffATKPotion);
               
                inventory.Remove(blazeFruitData);
                inventory.Remove(blazeFruitData);
                inventory.Remove(holyWaterData);

            }   
        }
        if(timerThree >=0){
            timerThree -= Time.deltaTime;
            if(timerThree <= 0){
                //add potion to player potion inventory
                playerCombat.ownedPotions.Add(healingPotion);
                inventory.Remove(citroFruitData);
                inventory.Remove(citroFruitData);
                inventory.Remove(holyWaterData);
            }
        }
    }

    public void CraftDefenseDebuffPotion(){
        if(timerOne <=0){
            if(inventory.FindLeisureBerryStack() >= 2 && inventory.FindHolyWaterStack() >= 1 ){
                timerOne = defenseDebuffPotionCraftTime;
                
            }
            else{
                print("Crafting materials insufficient!");
                print("Leisure Berry: " + inventory.FindLeisureBerryStack());
                print("Holy Water: " + inventory.FindHolyWaterStack());
            }
        }
        else{
            print("Defense Debuff Potion is crafting!");
        }
    }   
    public void CraftBuffATKPotion(){
        if(timerTwo <= 0){
            if(inventory.FindBlazeFruitStack() >= 2 && inventory.FindHolyWaterStack() >= 1 ){
                timerTwo = buffATKPotionCraftTime;
            }
            else{
                print("Crafting materials insufficient!");
                print("Blaze Fruit: " + inventory.FindBlazeFruitStack());
                print("Holy Water: " + inventory.FindHolyWaterStack());
            }
        }
         else{
            print("Attack Buff Potion is crafting!");
        }
        
        
    }
    public void CraftHealingPotion(){
        if(timerThree <= 0){
            if(inventory.FindCitroFruitStack() >= 2 && inventory.FindHolyWaterStack() >= 1 ){
                timerThree = healingPotionCraftTime;
            }
            else{
                print("Crafting materials insufficient!");
                print("Citro Fruit: " + inventory.FindCitroFruitStack());
                print("Holy Water: " + inventory.FindHolyWaterStack());
            }
        }
        else{
            print("Healing Potion is crafting!");
        }
    }
}
