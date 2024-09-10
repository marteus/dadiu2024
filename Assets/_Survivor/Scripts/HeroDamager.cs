using UnityEngine;

public class HeroDamager: MonoBehaviour
{
    public float DamagePerSecond;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Hero>(out var hero))
        {
            hero.Health.TakeDamage(DamagePerSecond * Time.deltaTime);
        }
    }

}
