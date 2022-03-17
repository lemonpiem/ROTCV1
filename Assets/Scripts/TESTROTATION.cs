using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTROTATION : MonoBehaviour
{


    [SerializeField] private Transform followTransform;
    Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    void Update()
    {

        //transform.LookAt(transform.position + new Vector3(movement.x, 0, movement.z));
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
        
        //Girar(movement);
    }

    private void Girar(Vector3 direccion)
    {
        if (direccion != Vector3.zero)
        {
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            transform.rotation = rotacion;
        }

    }
}
