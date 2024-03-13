using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    public int currentDefense;
    [SerializeField] int maxDefense;

    void Start()
    {
        currentDefense = maxDefense;
    }

    
}
