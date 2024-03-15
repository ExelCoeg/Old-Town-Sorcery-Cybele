using UnityEngine;
using System;
public class LeisureBerry : MonoBehaviour, ICollectible
{
    public static event HandleResourceCollected onLeisureBerryCollected;
    public delegate void HandleResourceCollected(ItemData itemData);
    public ItemData fruitData;
    public void Collect(){
        Destroy(gameObject);
        onLeisureBerryCollected?.Invoke(fruitData);
    }
}