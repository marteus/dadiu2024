using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mob : MonoBehaviour
{
    [SerializeField] MobSettings _settings;

    CharacterController _controller;

    Character _target;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _target = Object.FindAnyObjectByType<Character>();
    }
    
    void Update()
    {
        if (_target != null)
        {
            var delta = _target.transform.position - transform.position;
            if (delta.magnitude > 0)
            {
                var motion = delta.normalized * Time.deltaTime * _settings.MoveSpeed;
                _controller.Move(motion);
            }
        }
    }
}
