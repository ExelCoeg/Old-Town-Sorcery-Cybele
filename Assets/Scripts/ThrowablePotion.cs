
using UnityEngine;

public class ThrowablePotion : MonoBehaviour, IThrowable
{
    [SerializeField] float aoeRadius = 1f;
    [SerializeField] int decreaseAmount;
    [SerializeField] float disappearTime;

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
        }
        if (Vector2.Distance(targetPos, transform.position) <= 0.1f)
        { 
            isActivated = false;
            if(potionName== ThrowablePotionName.DEFENSE_DEBUFF)
            {
                if(TryGetComponent<DefenseDebuffPotion>(out DefenseDebuffPotion potionScript))
                {
                    potionScript.init(aoeRadius, decreaseAmount, disappearTime);
                }
            }
            //if(potionName == PotionName.SLOW)
            //{
            //    if(TryGetComponent<>)
            //}
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
