
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public TextMeshProUGUI leisureBerryText;
    public TextMeshProUGUI citroFruitText;
    public TextMeshProUGUI blazeFruitText;
    public TextMeshProUGUI holyWaterText;
    public TextMeshProUGUI defenseDebuffPotionText;
    public TextMeshProUGUI buffATKPotionText;
    public TextMeshProUGUI healingPotionText;
    public Inventory inventory;
    
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
    }
}
