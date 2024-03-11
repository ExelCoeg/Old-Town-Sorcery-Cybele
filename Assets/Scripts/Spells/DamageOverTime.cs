
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    /*------ Spell Attributes --------*/
    float speed;
    float aoeRadius;
    float aoeTime;
    float aoeDamage;
    float dotTime;
    float dotTimer;

    Vector2 targetPos;

    /*------ Private variable --------*/
    private bool isActivated;

   
    public void SetValues( float speed, float aoeRadius, float aoeDamage, float aoeTime, float dotTime)
    {
       
        this.speed = speed;
        this.aoeDamage = aoeDamage;
        this.aoeRadius = aoeRadius;
        this.aoeTime = aoeTime;
        this.dotTime = dotTime;
    }
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
        if (isActivated) StartAOE();

        else {
            MoveTowards(targetPos);
        }

        if (Vector2.Distance(transform.position, targetPos) <= 0.001f) isActivated = true;

    }
    void StartAOE()
    {
        Collider2D[] damagedObjs = Physics2D.OverlapCircleAll(transform.position, aoeRadius);
        foreach (Collider2D damageObj in damagedObjs)
        {
            dotTimer += Time.deltaTime;
            if (dotTimer >= dotTime)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                IDamagable damagable = damageObj.GetComponent<IDamagable>();
                if(damagable!=null) damagable.TakeDamage(aoeDamage + 0.4f * player.GetComponent<PlayerCombat>().attackDamage);
                dotTimer = 0;
            }
        }
        GetComponent<SpriteRenderer>().sprite = null;
        Transform foundEffect = transform.Find("Fire(Clone)");
        if (foundEffect)
        {
            var effect = foundEffect.GetComponent<ParticleSystem>();
            
            if (!effect.isPlaying) effect.Play();
            
            Destroy(gameObject, aoeTime);
        }
        GetComponent<LightOff>().targetPos = targetPos;
       
    }


    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) isActivated = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }
}
