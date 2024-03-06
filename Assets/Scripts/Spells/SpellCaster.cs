
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
     /*------------- cooldown timer ----------------*/

    public float fireballCooldown;
    public float scorchingCooldown;
    private void Update(){
        fireballCooldown -= Time.deltaTime;
        scorchingCooldown -= Time.deltaTime;

        // print("fireballCooldown: " + fireballCooldown);
        // print("scorchingCooldown: " + scorchingCooldown);
    }
    public void AOECast(AOESpell spell, Transform firePoint)
    {
        if(spell != null)
        {
            if(spell.name == "Fireball" && fireballCooldown <= 0)
            {
                print("casting: " + spell.spellName);
                GameObject spellClone = Instantiate(spell.spellGameObject,firePoint.position,firePoint.rotation);

                fireballCooldown = spell.cooldownTime;

                var spellType = spellClone.AddComponent<DamageOverTime>();

                spellType.SetValues(spell.speed, spell.aoeRadius, spell.aoeDamage, spell.spellFinishTime, spell.dotTime);
                var fireEffect = spellClone.AddComponent<FireEffect>();
                if (fireEffect)
                {
                    fireEffect.SetValues(spell.effect, firePoint);
                }
                GetComponent<PlayerMana>().currentMana -= spell.manaCost;
            }
            
        }
    }
    public void SingleTargetCast(SingleTargetSpell spell)
    {
        if(spell!= null){
            if(spell.name == "Scorching Blaze" && scorchingCooldown <= 0){
                scorchingCooldown = spell.cooldownTime;
                GameObject player=  GameObject.FindGameObjectWithTag("Player");
                player.AddComponent<ScorchingBlaze>();
            }
        }
    }
}
