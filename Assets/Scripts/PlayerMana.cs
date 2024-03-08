using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] int maxMana;
    public int currentMana;
    [SerializeField] Slider manaSlider;
    float usedUntilRegenTime = 2f;
    float usedTimer;
    float regenTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(usedTimer >= 0)
        {
            usedTimer -= Time.deltaTime;
        }
        if(currentMana < maxMana)
        {
            if(usedTimer <= 0)
            {
                regenTimer -= Time.deltaTime;
                if(regenTimer <= 0)
                {
                    IncreaseMana();
                    if(currentMana > maxMana)
                    {
                        currentMana = maxMana;
                    }
                    regenTimer = 1;
                }
        
            }
        }
        manaSlider.value = currentMana;
    }

    public void ResetUseTimer(){
        usedTimer = usedUntilRegenTime;
    }
    public void IncreaseMana(){
        currentMana += 10;
    }
    
}
