using UnityEngine;
using System;
public class LeisureBerry : MonoBehaviour, ICollectible
{
    public static event HandleResourceCollected onLeisureBerryCollected;
    public delegate void HandleResourceCollected(ItemData itemData);
    public ItemData fruitData;
    public void Collect(){
        print("Player collected Leisure Berry");
        Destroy(gameObject);
        onLeisureBerryCollected?.Invoke(fruitData);
    }
}