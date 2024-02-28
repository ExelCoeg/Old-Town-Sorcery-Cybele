using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Vector3 mousePos;
    public Spell[] spells; // <- ambigu

    public int currentSpell; 
    [SerializeField] GameObject firePoint;

    PlayerMana playerMana;

    private void Awake()
    {
        playerMana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.GetComponent<Rigidbody2D>().rotation = angle;
        firePoint.transform.position = transform.position;    
        if (Input.GetKeyDown(KeyCode.Space) && playerMana.currentMana >= spells[currentSpell].manaCost) {
            PlayerShoot();
        }
    }


    void SpellSwitching() 
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpell = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpell = 1;
        }
        
    }
    
    void PlayerShoot(){
        if(spells.Length >= 1)
        {
            GameObject fireballClone = Instantiate(spells[currentSpell].spellGameObject, firePoint.transform.position, firePoint.transform.rotation);
            playerMana.currentMana -= spells[currentSpell].manaCost;
        }
        else
        {
            print("Player has no spells");
        }
    }
}
