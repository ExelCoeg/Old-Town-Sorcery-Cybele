using UnityEngine;

public class Power: MonoBehaviour
{
    public Spell spell;
    private void Update()
    {
        spell.Invoke(this);
    }
}
