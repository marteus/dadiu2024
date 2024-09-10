using UnityEngine;

public class MainHeroHealthUI : MonoBehaviour
{
    [SerializeField] HealthUI _health;

    void OnEnable()
    {
        Hero.DamageTaken += OnDamageTaken;
    }

    void OnDisable()
    {
        Hero.DamageTaken -= OnDamageTaken;
    }

    void OnDamageTaken(Hero hero, float arg2)
    {
        _health.SetHealthRatio(arg2);
    }
}