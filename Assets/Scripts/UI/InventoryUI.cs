
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public TextMeshProUGUI leisureBerryText;
    public TextMeshProUGUI citroFruitText;
    public TextMeshProUGUI blazeFruitText;
    public TextMeshProUGUI holyWaterText;
    public Inventory inventory;
    
    // Update is called once per frame
    void Update()
    {
        leisureBerryText.text = inventory.FindLeisureBerryStack().ToString();
        citroFruitText.text = inventory.FindCitroFruitStack().ToString();
        blazeFruitText.text = inventory.FindBlazeFruitStack().ToString();
        holyWaterText.text = inventory.FindHolyWaterStack().ToString();
    }
}
