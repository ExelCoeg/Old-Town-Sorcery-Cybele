
using UnityEngine;
[CreateAssetMenu(menuName = "Spells/AOESpell")]
public class AOESpell: Spell
{
    public GameObject spellGameObject;
    [Header("AOE")]
    public float speed;
    public float aoeRadius;
    [Range(0, 1f)] public float aoeDamage;
    public float dotTime;
}
