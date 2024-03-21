
using UnityEngine;

public class ThrowablePotion : MonoBehaviour, IThrowable
{
    [SerializeField] float aoeRadius = 1f;
    [SerializeField] int decreaseAmount;
    [SerializeField] float disappearTime;
    float timer;
    public ThrowablePotionName potionName;
    public ThrowablePotionName PotionName { get { return PotionName; } }
    
    Vector2 targetPos;
    float speed;
    bool isActivated = false;
    private void Update()
    {
        if (isActivated)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            // timer += Time.deltaTime;
            // if(timer >= disappearTime){
            //     Destroy(gameObject);
            // }
        }
        if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
        { 
            if(potionName== ThrowablePotionName.DEFENSE_DEBUFF)
            {
                if(TryGetComponent<DefenseDebuffPotion>(out DefenseDebuffPotion potionScript))
                {
                    potionScript.init(aoeRadius, decreaseAmount, disappearTime);
                }
            }
            // AudioManager.instance.PlaySFX("potion_throw");
            
            // ParticleSystem 
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 targetPos, float speed)
    {
        isActivated = true;
        this.targetPos = targetPos;
        this.speed = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            isActivated = false;
        }
    }
}
