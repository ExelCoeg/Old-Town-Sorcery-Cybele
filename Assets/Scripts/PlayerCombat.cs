using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;

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

    /*---------- potions ----------*/
    int currentPotion;
    int throwSpeed;
    public List<GameObject> ownedPotions = new List<GameObject>();

    /*---------- attack attributes --------*/
    public Transform firePoint;
    public float attackRadius;
    public float attackDamage;
    public bool isAttacking;

    /*---------- State Variables----------- */
    int currentState = 0;
    public List<bool> onStates = new List<bool>();
    bool onMelee = true;
    bool onSpell = false;
    bool onPotion = false;
    /*
     onStates[0] = onMelee
     onStates[1] = onSpell
     onStates[2] = onPotion
      */

    /*---------- animation string variables ----------*/
    private string attack_parameter = "attack";
    private string onFireSpell_parameter = "player_spell_fire";
    private string onHealSpell_parameter ="player_spell_heal";
    private string idle_parameter = "player_idle";
    private string currentAnimation;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spellCaster = GetComponent<SpellCaster>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        
        onStates.Add(onMelee);
        onStates.Add(onSpell);
        onStates.Add(onPotion);
        
    }
    // Update is called once per frame
    void Update()
    {

        AimingAt();
        UpdateCurrentCombatStateText();
        PlayerAnimation();
        CycleState();

        
        if (onPotion && ownedPotions.Count > 0)
        {
            if (Input.GetMouseButtonDown(0)) ThrowPotion(ownedPotions[currentPotion], mousePos, throwSpeed);
        }

        if (onSpell)
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
        if(onMelee)
        {
            if (Input.GetMouseButtonDown(0) && !isAttacking) PlayerAttack();

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
   
    void UpdateCurrentCombatStateText()
    {
        if (onStates[0]) combatStateText.text = "Using: Sword" ;
        if (onStates[1] && ownedSpells.Count > 0) combatStateText.text = "Using: Spell: " + ownedSpells[currentSpell].spellName;
        if (onStates[2] && ownedPotions.Count > 0) combatStateText.text = "Using: Potion: " + ownedPotions[currentPotion].name;
    }
    void ThrowPotion(GameObject potion, Vector2 targetPos, float speed)
    {
        GameObject potionClone = Instantiate(potion, firePoint.position, Quaternion.identity);
        if(potionClone.TryGetComponent<IThrowable>(out IThrowable throwable))
        {
            throwable.Launch(targetPos, speed);
        }

        ownedPotions.Remove(potion);
        
    }
    void PlayerAnimation()
    {
        if (onStates[1] && ownedSpells.Count > 0)
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

    
    void CycleState()
    {
        if (Input.GetMouseButtonDown(1))
        {
            onStates[currentState] = false;
            currentState++;
            if(currentState >= onStates.Count)
            {
                currentState = 0;
            }
            onStates[currentState] = true;
            
        }
        
        onMelee = onStates[0];
        onSpell = onStates[1];
        onPotion = onStates[2];
    }
    
}
