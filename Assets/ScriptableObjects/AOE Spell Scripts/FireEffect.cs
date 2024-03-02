using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        ParticleSystem fireParticle = Instantiate(effect, new Vector2(firePoint.position.x,firePoint.position.y - 1f), Quaternion.identity);
        fireParticle.transform.SetParent(gameObject.transform);
    }
}
