
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
     /*------------- cooldown timer ----------------*/

    public float fireballCooldown;
    public float scorchingCooldown;
    private void Update(){
        if(fireballCooldown >= 0)fireballCooldown -= Time.deltaTime;
        
        if(scorchingCooldown >= 0)scorchingCooldown -= Time.deltaTime;


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
                GetComponent<PlayerMana>().ResetUseTimer();

            }
            
        }
    }
    public void SingleTargetCast(SingleTargetSpell spell, ParticleSystem effect)
    {
        if(spell!= null){
            if(spell.name == "Scorching Blaze" && scorchingCooldown <= 0){
                scorchingCooldown = spell.cooldownTime;
                GameObject player=  GameObject.FindGameObjectWithTag("Player");
                var script = player.AddComponent<ScorchingBlaze>();
                script.init(spell.damage,effect);
                GetComponent<PlayerMana>().currentMana -= spell.manaCost;
                GetComponent<PlayerMana>().ResetUseTimer();
            }
        }
    }
}
