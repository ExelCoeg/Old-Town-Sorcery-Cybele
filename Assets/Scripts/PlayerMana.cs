using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] Slider manaSlider;
    [Header("Mana Status")]
    [SerializeField] int maxMana;
    public int currentMana;
    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;    
    }

    // Update is called once per frame
    void Update()
    {
        manaSlider.value = currentMana;
    }
}
