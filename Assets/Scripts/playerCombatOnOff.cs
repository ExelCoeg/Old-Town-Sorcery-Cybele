using UnityEngine;
public class playerCombatOnOff : MonoBehaviour
{
    public PlayerCombat playerCombat;
    private void OnMouseEnter() {
        playerCombat.enabled = false;
    }
    private void OnMouseExit() {
        playerCombat.enabled = true;
    }
}
