using UnityEngine;
using System;
public class BlazeFruit : MonoBehaviour, ICollectible
{ 
    public static event HandleResourceCollected onBlazeFruitCollected;
    public delegate void HandleResourceCollected(ItemData itemData);
    public ItemData fruitData;
    public void Collect(){
        Destroy(gameObject);
        onBlazeFruitCollected?.Invoke(fruitData);
    }

 
}