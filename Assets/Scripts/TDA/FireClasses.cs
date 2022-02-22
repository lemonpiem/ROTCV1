using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireClasses : MonoBehaviour
{
    public string[] fireClasses;

    // Start is called before the first frame update
    void Start()
    {
        fireClasses = new string[5];
        Array();

        foreach (string fire in fireClasses)
        {
            Debug.Log(" Fire Type " + fire + " is Fire Classes' List");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Array()
    {
        fireClasses[0] = "DragonFire_1";
        fireClasses[1] = "DragonFire_2";
        fireClasses[2] = "DragonFire_3";
        fireClasses[3] = "DragonFire_4";
        fireClasses[4] = "DragonFire_5";
    }
}
