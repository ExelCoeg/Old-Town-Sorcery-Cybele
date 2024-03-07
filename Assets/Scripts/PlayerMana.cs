using UnityEngine.UI;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] int maxMana;
    public int currentMana;
    [SerializeField] Slider manaSlider;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1 && currentMana < maxMana)
        {
            currentMana += 10;
            timer = 0;
            if(currentMana > maxMana){
                currentMana = maxMana;
            }
        }


        manaSlider.value = currentMana;
    }
}
