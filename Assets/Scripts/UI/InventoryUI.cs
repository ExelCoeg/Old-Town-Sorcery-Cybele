
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Inventory Texts")]
    public TextMeshProUGUI leisureBerryText;
    public TextMeshProUGUI citroFruitText;
    public TextMeshProUGUI blazeFruitText;
    public TextMeshProUGUI holyWaterText;
    public TextMeshProUGUI defenseDebuffPotionText;
    public TextMeshProUGUI buffATKPotionText;
    public TextMeshProUGUI healingPotionText;

    [Header("Inventory Borders")]
    public Image defenseDebuffPotionBorder;
    public Image buffATKPotionBorder;
    public Image healingPotionBorder;
    public Image swordBorder;
    [Header("Script References")]
    public Inventory inventory;
    public PlayerCombat playerCombat;
    Color onStateColor = new Color(244f / 255f, 137f / 255f, 137f / 255f);
    Color defaultColor = new Color(1f,1f,1f,1f);
    
    // Update is called once per frame
    void Update()
    {
        leisureBerryText.text = inventory.FindLeisureBerryStack().ToString();
        citroFruitText.text = inventory.FindCitroFruitStack().ToString();
        blazeFruitText.text = inventory.FindBlazeFruitStack().ToString();
        holyWaterText.text = inventory.FindHolyWaterStack().ToString();
        defenseDebuffPotionText.text = inventory.FindDefenseDebuffPotionStack().ToString();
        healingPotionText.text = inventory.FindHealingPotionStack().ToString();
        buffATKPotionText.text = inventory.FindBuffATKPotionStack().ToString();
        

        if(playerCombat.onPotion && playerCombat.ownedPotions.Count > 0 ){
            if(playerCombat.ownedPotions[playerCombat.currentPotion].name == "Defense Debuff Potion"){
                buffATKPotionBorder.color = defaultColor;
                healingPotionBorder.color = defaultColor;
                defenseDebuffPotionBorder.color = onStateColor;
                print("test 1");
            }
            if(playerCombat.ownedPotions[playerCombat.currentPotion].name == "Heal Potion"){
                defenseDebuffPotionBorder.color = defaultColor;
                buffATKPotionBorder.color = defaultColor;
                healingPotionBorder.color = onStateColor;
                print("test 2");
            }
            if(playerCombat.ownedPotions[playerCombat.currentPotion].name == "Buff Attack Potion"){
                defenseDebuffPotionBorder.color = defaultColor;
                healingPotionBorder.color = defaultColor;
                buffATKPotionBorder.color = onStateColor;
                print("test 3");
            }
        }
        if(playerCombat.onMelee){
            //border on melee
            defenseDebuffPotionBorder.color = defaultColor;
            buffATKPotionBorder.color = defaultColor;
            healingPotionBorder.color = defaultColor;
            swordBorder.color = onStateColor;
        }
        else{
            swordBorder.color = defaultColor;
        }
    }
}
