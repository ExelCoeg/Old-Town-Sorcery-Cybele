
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{

    public int currentDefense;
    [SerializeField] int maxDefense;

    // Start is called before the first frame update
    void Start()
    {
        currentDefense = maxDefense;
    }


}
