using UnityEngine.UI;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] int maxMana;
    public int currentMana;
    [SerializeField] Slider manaSlider;
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
