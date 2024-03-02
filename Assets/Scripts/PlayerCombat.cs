using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    /*------ GetComponents -------*/
    Rigidbody2D rb;
    SpellCaster spellCaster;
    Animator anim;

    /*---------- UI -------------*/
    [SerializeField] TextMeshProUGUI combatStateText;


    Vector2 mousePos;

    /*---------- spells -----------*/
    int currentSpell;
    public List<Spell> ownedSpells = new List<Spell>();

    /*---------- attack attributes --------*/
    public Transform firePoint;
    public float attackRadius;
    public float attackDamage;
    public bool isAttacking;
    bool onMelee = true;

    /*---------- State Booleans ----------- */
    public bool onFireSpell;
    public bool onHealSpell;


    /*---------- animation string variables ----------*/
    private string attack_parameter = "attack";
    private string onFireSpell_parameter = "player_fireball_potion";
    private string onHealSpell_parameter ="player_healing_potion";
    private string idle_parameter = "player_idle";
    private string currentAnimation;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spellCaster = GetComponent<SpellCaster>();
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        AimingAt();
        UpdateCurrentCombatStateText();
        PlayerAnimation();

        print("onMelee: " + onMelee);

        
        if (!onMelee)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentSpell--;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentSpell++;
            }
            if (currentSpell < 0) currentSpell = 0;
            if (currentSpell >= ownedSpells.Count) currentSpell = ownedSpells.Count - 1;
            if (ownedSpells.Count > 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    onMelee = true;
                }
                if (Input.GetMouseButtonDown(0) && GetComponent<PlayerMana>().currentMana >= ownedSpells[currentSpell].manaCost)
                {
                    if (ownedSpells[currentSpell].GetType().Name == "AOESpell")
                    {
                        spellCaster.AOECast(ownedSpells[currentSpell] as AOESpell, firePoint);
                    }

                    if (ownedSpells[currentSpell].GetType().Name == "SelfTargetSpell")
                    {
                        spellCaster.SelfTargetCast(ownedSpells[currentSpell] as SelfTargetSpell, firePoint);
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking) PlayerAttack();
            if (Input.GetMouseButtonDown(1)) onMelee = false;
        }
    }
    void PlayerAttack()
    {
        isAttacking = true;
        anim.SetTrigger(attack_parameter);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(firePoint.position, attackRadius);
        foreach(Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth)) enemyHealth.currentHealth--;
        }
       
    }
    void AimingAt()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Vector3 currentRotation = firePoint.localEulerAngles;
        
        if (GetComponent<PlayerMovement>().isFacingRight) currentRotation.z = angle;
        else currentRotation.z = -angle;
        firePoint.localEulerAngles = currentRotation;
    }
    string GetCurrentCombatState()
    {
        if (!onMelee)
        {
            if(ownedSpells.Count > 0)
            {
                if (ownedSpells[currentSpell].name == "FireSpell")
                {
                    return "onFireSpell";
                }
                if (ownedSpells[currentSpell].name == "HealSpell")
                {
                    return "onHealSpell";
                }
            }
        }
        return "onMelee";
    }
    void UpdateCurrentCombatStateText()
    {
        if (onMelee) combatStateText.text = "Using: " + GetCurrentCombatState();
        else combatStateText.text = "Using: " + ownedSpells[currentSpell].spellName;
    }
    void PlayerAnimation()
    {
        if (!onMelee && ownedSpells.Count > 0)
        {
            if (ownedSpells[currentSpell].name == "FireSpell") ChangeAnimation(onFireSpell_parameter);
            if (ownedSpells[currentSpell].name == "HealSpell") ChangeAnimation(onHealSpell_parameter);
        }
        else
        {
            ChangeAnimation(idle_parameter);
        }

    }
    void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        anim.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
