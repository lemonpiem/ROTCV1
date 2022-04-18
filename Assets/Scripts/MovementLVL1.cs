using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLVL1 : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turningSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    [SerializeField] private CiriAnimation anim;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float jumpHeight = 3f;

    void Start()
    {
        anim = GetComponent<CiriAnimation>();
        anim.Idle();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        isGrounded = true;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(3 * -2 * gravity);
            isGrounded = false;
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)

        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turningSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);


        }

        if ((Mathf.Abs(direction.normalized.x) + Mathf.Abs(direction.normalized.z)) == 0)

        {

            anim.Idle();

        }
        else
        {
            anim.Walk();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }



    }

    private void Sprint()
    {
        sprintSpeed = speed + speed * 0.5f;
        anim.Run();

    }



}
