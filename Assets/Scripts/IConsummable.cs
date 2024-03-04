
using UnityEngine;

public enum ConsummablePotionName
{
    HEAL,
    ATK_BUFF
}
public interface IConsummable
{
    ConsummablePotionName PotionName { get; }

    public void Use();

}
