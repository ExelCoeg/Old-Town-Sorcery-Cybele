using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public void Cast(Spell spell, Transform firePoint)
    {
        if(spell != null)
        {
            print("casting: " + spell.spellName);

            //instantiate spell effects dll
            GameObject fireballClone = Instantiate(spell.spellObject, firePoint.position, firePoint.rotation);
            SpellMovement spellMovement = fireballClone.GetComponent<SpellMovement>();
            if(spellMovement != null)
            {
                spellMovement.setSpeed(spell.speed);
            }
          
            GetComponent<PlayerMana>().currentMana -= spell.manaCost;
            
        }
    }

    public void ApplySpellDamage(int damage)
    {
        return;
    }
    

}
