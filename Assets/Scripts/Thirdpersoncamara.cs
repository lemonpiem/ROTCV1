using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirdpersoncamara : MonoBehaviour
{

    public float sens = 100;
    public Transform playerBody;
    public float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
        print(xRotation);
    }
}