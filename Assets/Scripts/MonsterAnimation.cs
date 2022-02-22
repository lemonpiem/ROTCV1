using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
   
    public void Idle()
     {
            anim.SetFloat("Velocity", 0);

     }

    public void Walk()
     {
            anim.SetFloat("Velocity", 0.5f);
     }

    public void Run()
    {
            anim.SetFloat("Velocity", 1);
    }

    public void Shout()
    {
        anim.SetBool("IsTrigger", true);
    }
    
}
