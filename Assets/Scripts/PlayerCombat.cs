using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody2D rb;
    SpellCaster spellCaster;
    public Transform firePoint;
    Vector2 mousePos;
    int currentSpell;
    public List<Spell> ownedSpells = new List<Spell>();

    public float attackRadius;
    public float attackDamage;
    bool onMelee = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spellCaster = GetComponent<SpellCaster>();
    }
    
    // Update is called once per frame
    void Update()
    {
        AimingAt();
        if (currentSpell < 0) currentSpell = 0;
        if (currentSpell >= ownedSpells.Count) currentSpell = ownedSpells.Count - 1;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSpell--;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentSpell++;
        }

        if (!onMelee)
        {
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
                    if(ownedSpells[currentSpell].GetType().Name == "SelfTargetSpell")
                    {
                        spellCaster.SelfTargetCast(ownedSpells[currentSpell] as SelfTargetSpell, firePoint) ;
                    }
                }
            }
        }
        else
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                PlayerAttack();
            }
            if (Input.GetMouseButtonDown(1))
            {
                onMelee = false;
            }
        }
    }
    void PlayerAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(firePoint.position, attackRadius);
        foreach(Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth)){
                enemyHealth.currentHealth--;
            }
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
}
