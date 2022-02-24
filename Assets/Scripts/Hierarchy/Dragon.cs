using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerFind();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
}
