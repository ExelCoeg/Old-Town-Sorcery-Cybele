
using TMPro;
using UnityEngine;

public class Spell : ScriptableObject
{
    [Header("Spell")]
    public string tag;
    public string spellName;
    public int manaCost;
    public float spellFinishTime;
    public ParticleSystem effect;
}
