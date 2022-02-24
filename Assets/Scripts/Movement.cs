using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //[SerializeField] private float speed;
    //[SerializeField] private float jumpForce;
    public CiriInfo datos;
    private bool jump;
    private Rigidbody rb;
    Vector3 movement = Vector3.zero;
    private CiriAnimation anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<CiriAnimation>();
        anim.Idle();

        
    }

    private void FixedUpdate()
    {
        Move(movement);
        transform.LookAt(transform.position + new Vector3(movement.x, 0, movement.z));
        
    }

    // Update is called once per frame
    void Update()
    {

       movement.x = Input.GetAxisRaw("Horizontal");
       movement.z = Input.GetAxisRaw("Vertical");

       if (Input.GetKeyDown(KeyCode.Space)) 
       {
          jump = true;
          
       }



    }


    void Move(Vector3 movement)
    {
        rb.MovePosition(rb.position + movement.normalized * datos.speed * Time.fixedDeltaTime);
        
        if ((Mathf.Abs(movement.normalized.x) + Mathf.Abs(movement.normalized.z)) == 0)
        {
            anim.Idle();
        }
        else
        {
            anim.Walk();
        }
        

        if (jump == true)
        {
          rb.AddForce(Vector3.up * datos.jumpForce, ForceMode.Impulse);
            jump = false;
            
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Magic fire pro red")
        {
            StartCoroutine(Temp());
            
        }
    }

    private IEnumerator Temp()
    {
        yield return new WaitForSeconds(2f);
        anim.Victory();
    }

 }

