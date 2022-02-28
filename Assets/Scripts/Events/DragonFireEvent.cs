using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireEvent : MonoBehaviour

{
    public event Action onPickUp;

    // Start is called before the first frame update
    void Start()
    {
        onPickUp += onPickUpHandler;
        EventInvoker();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EventInvoker()
    {
        onPickUp?.Invoke();
    }

    public void onPickUpHandler()
    {
        Debug.Log("Event Test");
    }


}
