using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement_Level2 : MonoBehaviour
{

    [SerializeField] private CharacterController cc;
    [SerializeField] private float movespeed = 5;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private CiriInfo datos;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Vector3 speed;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private bool isGrounded;

    [SerializeField] private CiriAnimation anim;

    [SerializeField] private CinemachineVirtualCamera _followCamera;

    // Start is called before the first frame update
    void Start()
    {
        _followCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cc = GetComponent<CharacterController>();
        anim = GetComponent<CiriAnimation>();
        anim.SwordIdle();
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

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
            Debug.Log("Attack");  
        }
        

    }

    private void Sprint()
    {
        sprintSpeed = movespeed + movespeed * 0.5f;
        anim.SwordRun();
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


        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }



        if ((Mathf.Abs(move.normalized.x) + Mathf.Abs(move.normalized.z)) == 0)

        {

            anim.SwordIdle();

        }
        else
        {
            anim.SwordWalk();
        }

        
    }

    private IEnumerator Attack()
    {
        //Animación de ataque
        anim.Attack();
        yield return new WaitForSeconds(1.1f);
        anim.StopAttack();

    }
}

