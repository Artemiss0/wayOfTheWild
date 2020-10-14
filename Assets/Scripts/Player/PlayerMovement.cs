using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Object References")]
    public CharacterController Controller;
    public Transform Cam;
    public Transform GroundCheck;
    public LayerMask GroundMask;

    [Header("Player variables")]
    public float Speed = 6f;
    public float TurnSmoothTime = 0.1f;
    public float Gravity = -9f;
    public float GroundDistance = 0.4f;
    public float JumpHight = 3f;

    private Vector3 _velocity, _direction;
    private bool _isGrounded;
    private float _turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        _velocity.y += Gravity * Time.deltaTime;
        _direction = new Vector3(horizontal, 0f, vertical);

        Controller.Move(_velocity * Time.deltaTime);

        if(_direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            Controller.Move(moveDir * Speed * Time.deltaTime);
        }

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(JumpHight * -2f * Gravity);
        }
    }
}
