using UnityEngine;
public enum ThrowablePotionName
{
    DEFENSE_DEBUFF,
}
public interface IThrowable
{
    public ThrowablePotionName PotionName { get; }
    public void Launch(Vector2 direction, float speed);
}
