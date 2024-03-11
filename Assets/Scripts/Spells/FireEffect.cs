
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    ParticleSystem effect;
    Transform firePoint;
    public void SetValues(ParticleSystem effect,Transform firePoint)
    {
        this.effect = effect;
        this.firePoint = firePoint;
    }
    private void Start()
    {
        ParticleSystem fireParticle = Instantiate(effect, new Vector2(firePoint.position.x,firePoint.position.y), Quaternion.identity);
        fireParticle.transform.SetParent(gameObject.transform);
    }
}
