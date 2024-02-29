
using UnityEngine;
[CreateAssetMenu(menuName = "Spells/Spell")]
public class Spell : ScriptableObject
{
    public string spellName;
    public int manaCost;
    public float speed;
    public float aoeRadius;
    public int aoeDamage;
    //public GameObject effect;
    public GameObject spellObject;
}
