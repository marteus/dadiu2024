using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mob : MonoBehaviour
{

    public static List<Mob> Actives = new List<Mob>();



    [SerializeField] MobSettings _settings;

    CharacterController _controller;

    Hero _target;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _target = Object.FindAnyObjectByType<Hero>();
    }

    void OnEnable()
    {
        Actives.Add(this);
    }

    void OnDisable()
    {
        Actives.Remove(this);
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
