
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

    [Header("Fruit Datas")]
   public ItemData blazeFruitData;
   public ItemData citroFruitData;
   public ItemData leisureBerryData;
   public ItemData holyWaterData;
    public Inventory inventory;
    public PlayerCombat playerCombat;

    bool isAvailable_ddp = false;
    bool isAvailable_bap = false;
    bool isAvailable_hp = false;
    // Update is called once per frame
    // private void Start() {
    //     timerOne = defenseDebuffPotionCraftTime;
    //     timerTwo = buffATKPotionCraftTime;
    //     timerThree = healingPotionCraftTime;
    // }
    void Update()
    {
        print("isAvailable_ddp: " + isAvailable_ddp);
        print("isAvailable_bap: " + isAvailable_bap);
        print("isAvailable_hp: " + isAvailable_hp);
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
        if(timerOne >= 0){
            isAvailable_ddp = false;
            timerOne -= Time.deltaTime;
            defenseDebuffPotionCooldownIcon.fillAmount -= 1/defenseDebuffPotionCraftTime * Time.deltaTime;


            if(timerOne <= 0){
                //add potion to player potion inventory
                inventory.Remove(leisureBerryData);
                inventory.Remove(leisureBerryData);
                inventory.Remove(holyWaterData);
                playerCombat.ownedPotions.Add(defenseDebuffPotion);
            }
        }
        if(timerTwo>=0){
            isAvailable_bap = false;
            timerTwo -= Time.deltaTime;
            buffATKPotionCooldownIcon.fillAmount -= 1/buffATKPotionCraftTime * Time.deltaTime;


            if(timerTwo <= 0){
                //add potion to player potion inventory
                inventory.Remove(blazeFruitData);
                inventory.Remove(blazeFruitData);
                inventory.Remove(holyWaterData);
                playerCombat.ownedPotions.Add(buffATKPotion);
            }   
        }
        if(timerThree >=0){
            isAvailable_hp = false;
            timerThree -= Time.deltaTime;
            healingPotionCooldownIcon.fillAmount -= 1/healingPotionCraftTime * Time.deltaTime;


            if(timerThree <= 0){
                //add potion to player potion inventory
                inventory.Remove(citroFruitData);
                inventory.Remove(citroFruitData);
                inventory.Remove(holyWaterData);
                playerCombat.ownedPotions.Add(healingPotion);
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
