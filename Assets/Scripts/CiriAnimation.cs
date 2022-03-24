using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiriAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
           
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

    public void Jump()
    {
        anim.SetBool("IsGrounded", false);
        anim.SetFloat("VelocityY", 0.1f);
    }

    public void noJump()
    {
        anim.SetBool("IsGrounded", true);
    }

    public void Victory()
    {
        
        anim.SetBool("Ending", true);
    }

    public void Attack()
    {
        anim.SetBool("Fighting", true);
    }

    public void SwordIdle()
    {
        anim.SetBool("Sword", true);
        anim.SetFloat("Velocity", 0f);
    }

    public void SwordWalk()
    {
        anim.SetBool("Sword", true);
        anim.SetFloat("Velocity", 0.5f);
    }

    public void SwordRun()
    {
        anim.SetBool("Sword", true);
        anim.SetFloat("Velocity", 1f);
    }

    public void StopAttack()
    {
        anim.SetBool("Fighting", false);
    }
}
