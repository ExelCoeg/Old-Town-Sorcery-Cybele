using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();
    private void OnEnable() {
        BlazeFruit.onBlazeFruitCollected += Add;
        LeisureBerry.onLeisureBerryCollected += Add;
        HolyWater.onHolyWaterCollected += Add;
        CitroFruit.onCitroFruitCollected += Add;
            
    }
    private void OnDisable() {
        BlazeFruit.onBlazeFruitCollected -= Add;
        LeisureBerry.onLeisureBerryCollected -= Add;
        HolyWater.onHolyWaterCollected -= Add;
        CitroFruit.onCitroFruitCollected -= Add;
      
    }
    public void Add(ItemData itemData){
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            print($"{item.itemData.displayName} total stack is now {item.stackSize}");
        }
        else
        {
            print("there is no "+ itemData.displayName +"in dictionary");
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData,newItem);
            print($"Added {itemData.displayName} to the inventory for the first time.");
        }
    }
   
    public void Remove(ItemData itemData){
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item)){
            item.RemoveFromStack();
            if(item.stackSize==0){
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }
    public int FindLeisureBerryStack(){
        foreach(var item in inventory){
            if(item.itemData.displayName == "Leisure Berry"){
                return item.stackSize;
            }
        }
        return 0;
    }
    public int FindBlazeFruitStack(){
        foreach(var item in inventory){
            if(item.itemData.displayName == "Blaze Fruit"){
                return item.stackSize;
            }
        }
        return 0;
    }
    public int FindCitroFruitStack(){
        foreach(var item in inventory){
            if(item.itemData.displayName == "Citro Fruit"){
                return item.stackSize;
            }
        }
        return 0;
    }
    public int FindHolyWaterStack(){
        foreach(var item in inventory){
            if(item.itemData.displayName == "Holy Water"){
                return item.stackSize;
            }
        }
        return 0;
    }
}
