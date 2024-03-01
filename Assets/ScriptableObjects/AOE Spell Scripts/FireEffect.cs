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
        ParticleSystem fireParticle = Instantiate(effect, firePoint.position, Quaternion.identity);
        fireParticle.transform.SetParent(gameObject.transform);
    }
}
