using System.Collections.Generic;
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
    public float SuperJumpHeight = 20f;
    public float PlayerClimbSpeed = 35f;

    private Vector3 _velocity, _direction;
    private bool _isGrounded;
    private float _turnSmoothVelocity;
    private bool _isClimbing;
    private bool _canSuperJump;



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
            if (_canSuperJump)
            {
                _velocity.y = Mathf.Sqrt(SuperJumpHeight * -2f * Gravity);
            }
            else
            {
                _velocity.y = Mathf.Sqrt(JumpHight * -2f * Gravity);
            }
        }

        PlayerSprint();
        CheckPlayerAbilities();
    }

    private void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 14f;
        }
        else
        {
            Speed = 6f;
        }
    }

    private void CheckPlayerAbilities()
    {
        AnimalAbilityNameEnum activeAbility = gameObject.GetComponent<PlayerAbilities>().ActiveAbility;
        switch (activeAbility)
        {
            case AnimalAbilityNameEnum.Squirrel:
                PlayerClimb();
                RemoveSuperJump();
                break;
            case AnimalAbilityNameEnum.Frog:
                PlayerSumperJump();
                break;
            case AnimalAbilityNameEnum.Spider:
                PlayerHookshot();
                RemoveSuperJump();
                break;
            default:
                RemoveSuperJump();
                break;
        }
    }

    private void PlayerClimb()
    {
        RaycastHit hitWall;
        if (Physics.Raycast(transform.position, transform.forward, out hitWall, 1))
        {
            if (hitWall.transform.gameObject.name.Equals("Wall")) {
                if(Input.GetKey(KeyCode.Space))
                {
                    _isClimbing = true;
                    if (_isClimbing)
                    {
                        Gravity = 0;
                        Controller.transform.position += new Vector3(0f, PlayerClimbSpeed, 0f) * Time.deltaTime;
                    }
                } else
                {
                    _isClimbing = false;
                    Gravity = -36f;
                }
            } else
            {
                _isClimbing = false;
                Gravity = -36f;
            }
        } else
        {
            _isClimbing = false;
            Gravity = -36f;
        }
    }

    private void PlayerHookshot()
    {
        RaycastHit hitHookShot;
        if (Physics.Raycast(Cam.transform.position, transform.forward, out hitHookShot))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 hookPosition = new Vector3(hitHookShot.transform.position.x, hitHookShot.transform.position.y, hitHookShot.transform.position.z - 1.5f);
                transform.position = hookPosition;
            }
        }
    }

    private void RemoveSuperJump()
    {
        _canSuperJump = false;
    }
    private void PlayerSumperJump()
    {
        _canSuperJump = true;
    }
}
