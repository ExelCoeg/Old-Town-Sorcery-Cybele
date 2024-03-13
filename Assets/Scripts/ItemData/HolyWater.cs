using UnityEngine;
using System;
public class HolyWater : MonoBehaviour, ICollectible
{
    public static event HandleResourceCollected onHolyWaterCollected;
    public delegate void HandleResourceCollected(ItemData itemData);

    public ItemData holyWaterData;

   
    public void Collect(){
        print("Player collected Holy Water");
        Destroy(gameObject);
        onHolyWaterCollected?.Invoke(holyWaterData);
    }
}