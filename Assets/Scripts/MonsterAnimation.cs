using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

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
    
    public void DrownerAttack()
    {
        anim.SetBool("Fighting", true);
    }

    public void DrownerRecievingDamage()
    {
        anim.SetBool("RecivingDamage", true);
    }

    public void StopDrownerAttack()
    {
        anim.SetBool("Fighting", false);
    }

    public void Death()
    {
        anim.SetBool("IsDead", true);
    }
}
