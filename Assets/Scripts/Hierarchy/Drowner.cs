using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Drowner : Enemies
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rayP;
    [SerializeField] private bool isMoving;
    private MonsterAnimation anim;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private Vignette _vignette;

    new void Start()
    {
        PlayerFind();
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

    new void Update()
    {
        RayControl();
    }

    private void Move()
    {
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        rb.MovePosition(rb.position + (playerTransform.position - transform.position) * speed * Time.fixedDeltaTime);
    }

    void RayControl()
    {
        RaycastHit hit;
        Ray ray = new Ray(rayP.position, rayP.transform.TransformDirection(Vector3.forward));

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
            
            anim.Shout();
            volume.profile.TryGetSettings(out _vignette);
            _vignette.intensity.value = 0.513f;

        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player Cirilla")
        {
            
            volume.profile.TryGetSettings(out _vignette);
            _vignette.intensity.value = 0;

        }

    }

}
