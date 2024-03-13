using UnityEngine;
using System;
public class BlazeFruit : MonoBehaviour, ICollectible
{ 
    public static event HandleResourceCollected onBlazeFruitCollected;
    public delegate void HandleResourceCollected(ItemData itemData);
    public ItemData fruitData;
    public void Collect(){
        print("Player collected Blaze Fruit");
        Destroy(gameObject);
        onBlazeFruitCollected?.Invoke(fruitData);
    }
 
}