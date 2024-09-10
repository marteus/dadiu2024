using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    void Awake()
    {
        Instance = this;
    }
}
