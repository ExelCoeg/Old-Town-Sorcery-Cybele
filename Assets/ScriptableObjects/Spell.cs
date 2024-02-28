using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public GameObject spellGameObject;
    public int manaCost;
    public float speed;
    public int damage;
    public int disappearTime;
    public abstract void Invoke(Power power);
}
