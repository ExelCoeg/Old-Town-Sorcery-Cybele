using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public static SpellManager instance;
    public List<Spell> spells = new List<Spell>();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public Spell GetSpell(string spellName)
    {
        return spells.Find(spell => spell.spellName == spellName);
    }
}
