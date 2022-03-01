using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour

{
    public UnityEvent DragonFlamePU;


    private void Start()
    {
        Invoker();
    }

    private void Update()
    {
        
    }

    void Invoker()
    {
        DragonFlamePU?.Invoke();
    }

    void StartFlamePU() 
    { 
    
    }


}



