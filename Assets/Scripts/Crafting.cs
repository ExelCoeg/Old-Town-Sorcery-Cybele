    
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Crafting : MonoBehaviour
{
    float timerOne;
    float timerTwo;
    float timerThree;

    
    [Header("Potions Crafting Time")]
    public float defenseDebuffPotionCraftTime = 2;
    public float buffATKPotionCraftTime = 2;
    public float healingPotionCraftTime = 2;

    [Header("Potion Cooldown Icons")]
    public Image defenseDebuffPotionCooldownIcon;
    public Image buffATKPotionCooldownIcon;
    public Image healingPotionCooldownIcon;
    
    [Header("Potion Game Objects")]
    [SerializeField] GameObject defenseDebuffPotion;
    [SerializeField] GameObject buffATKPotion;
    [SerializeField] GameObject healingPotion;


    public PlayerCombat playerCombat;
    public Inventory inventory;
    public ItemList itemList;

    bool isAvailable_ddp = false;
    bool isAvailable_bap = false;
    bool isAvailable_hp = false;
    void Update()
    {



       //ngecek kalau bahannya ready dan lagi ga crafting
       // kalau ready, bikin cooldown iconnya jadi 0
       if(timerOne <= 0){
        if(inventory.FindLeisureBerryStack() >= 2 && inventory.FindHolyWaterStack() >= 1 ){
            print("test 1");
            isAvailable_ddp = true;
            defenseDebuffPotionCooldownIcon.fillAmount = 0;
        }
        if(inventory.FindLeisureBerryStack() < 2 || inventory.FindHolyWaterStack() < 1 ){
            defenseDebuffPotionCooldownIcon.fillAmount = 1;
            isAvailable_ddp = false;
        }
       }
        if(timerTwo <= 0){
            if(inventory.FindBlazeFruitStack() >= 2 && inventory.FindHolyWaterStack() >= 1 ){
                buffATKPotionCooldownIcon.fillAmount = 0;
                isAvailable_bap = true;
            }
            if(inventory.FindBlazeFruitStack() < 2 || inventory.FindHolyWaterStack() < 1){
                buffATKPotionCooldownIcon.fillAmount = 1;
                isAvailable_bap = false;
            }
        }
        if(timerThree <= 0){
            if(inventory.FindCitroFruitStack() >= 2 && inventory.FindHolyWaterStack() >= 1){
                healingPotionCooldownIcon.fillAmount = 0;
                isAvailable_hp = true;
            }
            if(inventory.FindCitroFruitStack() < 2 || inventory.FindHolyWaterStack() < 1 ){
                healingPotionCooldownIcon.fillAmount = 1;
                isAvailable_hp = false;
            }
        }
        

        // is crafting
        if(timerOne > 0){
            isAvailable_ddp = false;
            timerOne -= Time.deltaTime;
            defenseDebuffPotionCooldownIcon.fillAmount -= 1/defenseDebuffPotionCraftTime * Time.deltaTime;


            if(timerOne <= 0){
                inventory.Remove(itemList.leisureBerryData);
                inventory.Remove(itemList.leisureBerryData);
                inventory.Remove(itemList.holyWaterData);
                playerCombat.ownedPotions.Add(defenseDebuffPotion);
                inventory.Add(itemList.defenseDebuffPotionData);
            }
        }
        if(timerTwo>0){
            isAvailable_bap = false;
            timerTwo -= Time.deltaTime;
            buffATKPotionCooldownIcon.fillAmount -= 1/buffATKPotionCraftTime * Time.deltaTime;


            if(timerTwo <= 0){
                inventory.Remove(itemList.blazeFruitData);
                inventory.Remove(itemList.blazeFruitData);
                inventory.Remove(itemList.holyWaterData);
                playerCombat.ownedPotions.Add(buffATKPotion);
                inventory.Add(itemList.buffATKPotionData);
            }   
        }
        if(timerThree >0){
            isAvailable_hp = false;
            timerThree -= Time.deltaTime;
            healingPotionCooldownIcon.fillAmount -= 1/healingPotionCraftTime * Time.deltaTime;


            if(timerThree <= 0){
                inventory.Remove(itemList.citroFruitData);
                inventory.Remove(itemList.citroFruitData);
                inventory.Remove(itemList.holyWaterData);
                playerCombat.ownedPotions.Add(healingPotion);
                inventory.Add(itemList.healingPotionData);
            }
        }
    }
    public void CraftDefenseDebuffPotion(){
        if(timerOne <=0){
            if(isAvailable_ddp){
                timerOne = defenseDebuffPotionCraftTime;
                defenseDebuffPotionCooldownIcon.fillAmount = 1;
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
            if(isAvailable_bap){
                timerTwo = buffATKPotionCraftTime;
                buffATKPotionCooldownIcon.fillAmount = 1;
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
            if(isAvailable_hp){
                timerThree = healingPotionCraftTime;
                healingPotionCooldownIcon.fillAmount = 1;
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
