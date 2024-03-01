using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public static SpellManager instance;
    
    public List<Spell> spells = new List<Spell>();

    //public List<GameObject> selfTargetScripts = new List<GameObject>();
    //public List<GameObject> targetableScripts = new List<GameObject>();
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
