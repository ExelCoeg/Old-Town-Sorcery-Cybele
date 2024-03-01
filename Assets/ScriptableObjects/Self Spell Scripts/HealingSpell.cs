using UnityEngine;

public class HealingSpell : MonoBehaviour
{
    float spellFinishTime;
    private void Start()
    {
        GetComponent<ParticleSystem>().Play();
        GetComponentInParent<PlayerHealth>().currentHealth += 30;
    }
    public void SetValues(float spellFinishTime)
    {
        this.spellFinishTime = spellFinishTime;
    }
    private void Update()
    {
        Destroy(gameObject, spellFinishTime);
    }
}
