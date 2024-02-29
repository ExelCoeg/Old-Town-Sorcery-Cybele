using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMovement : MonoBehaviour
{
    Vector2 targetPos;
    float speed;
    float aoeRadius;
    int aoeDamage;
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void SetValues(float aoeRadius, int aoeDamage)
    {
        this.aoeDamage = aoeDamage;
        this.aoeRadius = aoeRadius;
    }
    // Start is called before the first frame update
    void Start()
    {

        Vector3 tempRotation = transform.eulerAngles;
        tempRotation.z += 180;
        transform.eulerAngles = tempRotation;
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPos)<=0.1f)
        {
            StartAOE();
        }
    }
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    void StartAOE()
    {
        //detect damagable objects di range aoe 
        Collider2D[] damagedObjs = Physics2D.OverlapCircleAll(transform.position, aoeRadius);
        foreach (Collider2D damageObj in damagedObjs)
        {
            IDamagable damagable = damageObj.GetComponent<IDamagable>();
            damagable.TakeDamage(aoeDamage);

        }
        sr.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            StartAOE();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
