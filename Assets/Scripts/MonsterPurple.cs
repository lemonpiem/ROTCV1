using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPurple : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rayP;
    [SerializeField] private bool isMoving;
    private MonsterAnimation anim;

    void Start()
    {
        player = GameObject.Find("Player Cirilla").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<MonsterAnimation>();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void Update()
    {
        RayControl();
    }

    private void Move()
    {
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        rb.MovePosition(rb.position + (player.position - transform.position) * speed * Time.fixedDeltaTime);
    }

    void RayControl()
    {
        RaycastHit hit;
        Ray ray = new Ray(rayP.position, rayP.transform.TransformDirection(Vector3.back));

        if (Physics.Raycast(ray, out hit, 500))
        {
            if (hit.collider.name == "Player Cirilla")

            {

                isMoving = true;
                anim.Run();

            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player Cirilla")
        {
            Debug.Log("Ciri: Agggh");
            anim.Shout();

        }

    }


}


