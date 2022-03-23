using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciri_Attack : MonoBehaviour
{

    public CiriAnimation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<CiriAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            Attack();
        }
    }

    void Attack()
    {
        //Animación de ataque
        anim.Attack();
    }
}
