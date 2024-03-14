using UnityEngine;
using UnityEngine.UI;

public class WellCooldownUI : MonoBehaviour {
    public Slider cooldownSlider;
    public Well well;
     private void Update() {
        cooldownSlider.value = well.cooldown;
        
        
     }
}