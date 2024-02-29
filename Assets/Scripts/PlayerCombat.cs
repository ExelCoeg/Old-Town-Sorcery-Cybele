using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Rigidbody2D rb;
    SpellCaster spellCaster;
    public Transform firePoint;
    Vector2 mousePos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spellCaster = GetComponent<SpellCaster>();
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Vector3 currentRotation = firePoint.localEulerAngles;

        currentRotation.z = angle;
        firePoint.localEulerAngles = currentRotation;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spell fireballSpell = SpellManager.instance.GetSpell("Fireball");

            if (fireballSpell != null)
            {
                spellCaster.Cast(fireballSpell, firePoint);
            }
            
        }
    }
}
