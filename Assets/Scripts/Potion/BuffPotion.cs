
using UnityEditor.SceneManagement;
using UnityEngine;

public class BuffPotion : MonoBehaviour
{
    float timer;
    ConsummablePotion potion;
    float effectTime;
    public ConsummablePotionName potionName;
    public ConsummablePotionName PotionName { get { return potionName; } }
    public void init(float effectTime)
    {
        this.effectTime = effectTime;
    }
    private void Awake()
    {
        potion = GetComponent<ConsummablePotion>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (potionName == ConsummablePotionName.ATK_BUFF)
        {
            GetComponent<PlayerCombat>().attackDamage += (potion.percentageAmount / 100) * GetComponent<PlayerCombat>().attackDamage;
        }
        // add condition kalau mau add potion buff baru
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= effectTime)
        {
            GetComponent<PlayerCombat>().attackDamage = GetComponent<PlayerCombat>().maxAttackDamage;
            Destroy(this);
        }
    }
}
