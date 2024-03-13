using UnityEngine;
using System;
public class CitroFruit : MonoBehaviour, ICollectible
{
    public static event HandleResourceCollected onCitroFruitCollected;
    public delegate void HandleResourceCollected(ItemData itemData);

    public ItemData fruitData;

   
    public void Collect(){
        print("Player collected Citro Fruit");
        Destroy(gameObject);
        onCitroFruitCollected?.Invoke(fruitData);
    }
}