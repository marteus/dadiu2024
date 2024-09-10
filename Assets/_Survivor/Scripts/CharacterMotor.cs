using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMotor : MonoBehaviour
{
    [SerializeField] CharacterMotorSettings _config;

    CharacterController _controller;

    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        Vector2 input = new() { x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical")};


        Vector3 moveDirection = Vector3.right * input.x + Vector3.forward * input.y;

        var right = Vector3.right;
        var forward = Vector3.forward;

        var velocityOnRight = Vector3.Dot(_velocity, right);
        var velocityOnForward = Vector3.Dot(_velocity, forward);
        

        var velocity = Mathf.MoveTowards(velocityOnRight, input.x, _config.Accelleration * Time.deltaTime);


        moveDirection.Normalize();

        _controller.Move(moveDirection * _config.MaxSpeed * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _velocity -= Vector3.Project(_velocity, hit.normal);
    }
}
