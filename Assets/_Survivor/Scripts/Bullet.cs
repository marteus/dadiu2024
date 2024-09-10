using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public event System.Action HitMob;

    public bool IsDone { get; private set; }

    [SerializeField] float _speed = 20;
    [SerializeField] float _duration = 2;


    float _elapsedTime;

    Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ResetState()
    {
        _elapsedTime = 0;
        IsDone = false;
    }


    public void UpdateState()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _duration)
            IsDone = true;

        _rigidbody.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Mob>(out var mob))
        {
            IsDone = true;
            HitMob?.Invoke();
        }

    }

}
