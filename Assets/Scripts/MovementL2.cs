using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovementL2 : MonoBehaviour
{

    public CharacterController cc;
    public float movespeed = 5;
    public float sprintSpeed;
    public float rotationSpeed;

    public float gravity = -9.81f;
    public Vector3 speed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    public bool isGrounded;

    public CiriAnimation anim;

    [SerializeField] private CinemachineVirtualCamera _followCamera;

    // Start is called before the first frame update
    void Start()
    {
        _followCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cc = GetComponent<CharacterController>();
        anim = GetComponent<CiriAnimation>();
        anim.Idle();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        isGrounded = true;

        if (isGrounded && speed.y < 0)
        {
            speed.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            speed.y = Mathf.Sqrt(3 * -2 * gravity);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }

    }

    private void Sprint()
    {
        sprintSpeed = movespeed + movespeed * 0.5f;
        anim.Run();
    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");


        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(x, 0, z);
        Vector3 movementDirection = movementInput.normalized;

        cc.Move(move * movespeed * Time.deltaTime);

        speed.y += gravity * Time.deltaTime;
        cc.Move(speed * Time.deltaTime);

        Debug.Log(movementDirection);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }



        if ((Mathf.Abs(move.normalized.x) + Mathf.Abs(move.normalized.z)) == 0)

        {

            anim.Idle();

        }
        else
        {
            anim.Walk();
        }
    }
}

