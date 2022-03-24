using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONSTERTEST : MonoBehaviour
{

    public MonsterAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<MonsterAnimation>();
        anim.Walk();
    }

    // Update is called once per frame
    void Update()
    {
        anim.DrownerAttack();
    }
}
