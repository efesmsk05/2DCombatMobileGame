using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieState : BossState
{   
    public BossDieState(Boss boss) : base(boss)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        //Debug.Log("Boss is entering die state.");
        boss.animator.SetBool("Died" , true);
        boss.uiManager.BossDefeated();

    }

    public override void Update()
    {

    }


    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        //Debug.Log("Boss is exiting die state.");
        boss.animator.SetBool("Died", false);

    }
}
