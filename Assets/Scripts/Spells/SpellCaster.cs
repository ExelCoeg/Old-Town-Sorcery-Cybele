
using UnityEngine;
using UnityEngine.UI;
public class SpellCaster : MonoBehaviour
{
    /*--------------- layer mask------------------*/
    public LayerMask enemyLayer;
     /*------------- cooldown timer ----------------*/

    float fireballCooldown;
    float fireballCooldownTimer;
    float scorchingCooldown;
    float scorchingCooldownTimer;


    /*------------- Skill Icons ----------------*/

    public Image fireballCooldownIcon;
    public Image scorchingBlazeCooldownIcon;
    

    bool isAvailable_Fireball =true;
    bool isAvailable_ScorchingBlaze = true;
    private void Update(){
        if(fireballCooldown >= 0 && !isAvailable_Fireball){
            isAvailable_Fireball = false;
            fireballCooldownTimer -= Time.deltaTime;
            fireballCooldownIcon.fillAmount -= 1/fireballCooldown * Time.deltaTime;
        }
        if(scorchingCooldown >= 0 && !isAvailable_ScorchingBlaze){
            isAvailable_ScorchingBlaze = false;
            scorchingCooldownTimer -= Time.deltaTime;
            scorchingBlazeCooldownIcon.fillAmount -= 1/scorchingCooldown * Time.deltaTime;
        }
        if(fireballCooldown <= 0){
            fireballCooldownIcon.fillAmount = 0;
           isAvailable_Fireball = true;
        }
        if(scorchingCooldown <= 0){
            scorchingBlazeCooldownIcon.fillAmount = 0;
           isAvailable_ScorchingBlaze = true;
        }
    }

    public void AOECast(AOESpell spell, Transform firePoint)
    {
        if(spell != null)
        {
            if(spell.name == "Fireball" && fireballCooldownTimer <= 0)
            {
                isAvailable_Fireball = false;
                print("casting: " + spell.spellName);
                GameObject spellClone = Instantiate(spell.spellGameObject,firePoint.position,firePoint.rotation);

                fireballCooldownTimer = fireballCooldown = spell.cooldownTime;
                fireballCooldownIcon.fillAmount = 1;
                var spellType = spellClone.AddComponent<DamageOverTime>();

                spellType.SetValues(spell.speed, spell.aoeRadius, spell.aoeDamage, spell.spellFinishTime, spell.dotTime,enemyLayer);
                var fireEffect = spellClone.AddComponent<FireEffect>();
                if (fireEffect)
                {
                    fireEffect.SetValues(spell.effect, firePoint);
                }
                GetComponent<PlayerMana>().currentMana -= spell.manaCost;
                GetComponent<PlayerMana>().ResetUseTimer();
                AudioManager.instance.PlaySFX("firespells");

            }
            
        }
    }
    public void SingleTargetCast(SingleTargetSpell spell, ParticleSystem effect)
    {
        if(spell!= null){
            if(spell.name == "Scorching Blaze" && scorchingCooldownTimer <= 0){
                isAvailable_ScorchingBlaze = false;
                scorchingCooldownTimer = scorchingCooldown = spell.cooldownTime;
                scorchingBlazeCooldownIcon.fillAmount = 1;
                GameObject player=  GameObject.FindGameObjectWithTag("Player");
                var script = player.AddComponent<ScorchingBlaze>();
                script.init(spell.damage,effect);
                GetComponent<PlayerMana>().currentMana -= spell.manaCost;
                GetComponent<PlayerMana>().ResetUseTimer();
                AudioManager.instance.PlaySFX("firespells");

            }
        }
    }
}
