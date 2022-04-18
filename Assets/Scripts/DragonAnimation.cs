using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour
{

    [SerializeField] private Animator anim;

    public void Scream()
    {
        anim.SetBool("SeesPlayer",true);

    }

    public void Idle()
    {
        anim.SetBool("SeesPlayer", false);
    }
    public void FlameAttack()
    {
        anim.SetBool("SeesPlayer", true);
        anim.SetBool("PlayerAttacking", true);
    }

    public void StopAttack()
    {
        anim.SetBool("SeesPlayer", true);
        anim.SetBool("PlayerAttacking", false);
        anim.SetBool("PlayerHit", false);
    }

    public void GetHit()
    {
        anim.SetBool("PlayerHit", true);
        
    }

    public void DragonDeath()
    {
        anim.SetBool("IsDead", true);

    }


}
