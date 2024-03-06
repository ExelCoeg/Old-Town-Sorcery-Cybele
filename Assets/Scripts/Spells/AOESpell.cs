
using UnityEngine;
[CreateAssetMenu(menuName = "Spells/AOESpell")]
public class AOESpell: Spell
{
    public GameObject spellGameObject;
    [Header("AOE")]
    public float speed;
    public float aoeRadius;
    public float aoeDamage;
    public float spellFinishTime;

    public float dotTime;
    [Header("Spell Particle/Effect")]
    public ParticleSystem effect;

}
