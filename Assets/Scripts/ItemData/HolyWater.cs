using UnityEngine;
public class HolyWater : MonoBehaviour, ICollectible
{
    public static event HandleResourceCollected onHolyWaterCollected;
    public delegate void HandleResourceCollected(ItemData itemData);

    public ItemData holyWaterData;

        
    public void Collect(){
        Destroy(gameObject);
        onHolyWaterCollected?.Invoke(holyWaterData);
    }
}