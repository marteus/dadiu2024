using UnityEngine;

[RequireComponent(typeof(HeroMotor))]
public class Hero : MonoBehaviour
{
    public static System.Action<Hero, float> DamageTaken;


    [SerializeField] Health _health;
    HeroMotor _motor;

    public Health Health => _health;

    public static Hero Instance;

    void Awake()
    {
        Instance = this;

        _motor = GetComponent<HeroMotor>();

        _health.Died.AddListener(() => 
        {
            _motor.enabled = false;
        });

        _health.DamageTaken.AddListener(args =>
        {
            DamageTaken?.Invoke(this, args.CurrentRatio);
        });

    
    }

    void Start()
    {
        DamageTaken?.Invoke(this, _health.CurrentHealth);
    }

    public void Teleport(Vector3 position, Quaternion rotation)
    {
        _motor.Teleport(position, rotation);
    }
}
