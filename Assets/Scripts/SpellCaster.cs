
using Unity.VisualScripting;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public void AOECast(AOESpell spell, Transform firePoint)
    {
        if(spell != null)
        {
            print("casting: " + spell.spellName);
            GameObject spellClone = Instantiate(spell.spellGameObject,firePoint.position,firePoint.rotation);

            if (spell.tag == "damageOverTime")
            {
                var spellType = spellClone.AddComponent<DamageOverTime>();
                if(spell.name == "FireSpell")
                {
                    var fireEffect = spellClone.AddComponent<FireEffect>();
                    spellType.SetValues(spell.speed, spell.aoeRadius, spell.aoeDamage, spell.spellFinishTime, spell.dotTime);
                    if (fireEffect)
                    {
                        fireEffect.SetValues(spell.effect, firePoint); ;
                    }
                }
            }
            
            GetComponent<PlayerMana>().currentMana -= spell.manaCost;
            
        }
    }
    public void SelfTargetCast(SelfTargetSpell spell, Transform firePoint)
    {
        if (spell != null)
        {
            print("casting: " + spell.spellName);
            GameObject spellScript = Instantiate(spell.spellScript, transform.position, Quaternion.identity);
            spellScript.transform.SetParent(gameObject.transform);
            if (spell.tag == "buff")
            {
                if(spell.name == "HealSpell")
                {
                    var healingScript = spellScript.AddComponent<HealingSpell>();
                    healingScript.SetValues(spell.spellFinishTime);
                }
            }
            GetComponent<PlayerMana>().currentMana -= spell.manaCost;
        }
    }
 
   
    

}
