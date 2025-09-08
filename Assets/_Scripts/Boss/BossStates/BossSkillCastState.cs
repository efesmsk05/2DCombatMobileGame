using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillCastState : BossState
{
    public BossSkillCastState(Boss boss) : base(boss)
    {
        this.boss = boss;
    }
    public override void Enter()
    {


        boss.animator.SetBool("Attack", true);

        boss.getPlayerDirection();

        //Debug.Log("Boss is entering skill state.");
        boss.ExecuteRandomSkill(boss);
        // skill animasyonu oynaayacak ve sonra skill animasyonundaki eventte ýdle geçiricek
    }

    public override void Update()
    {
    }


    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        boss.animator.SetBool("Attack", false);

        //Debug.Log("Boss is exiting skill state.");
    }
}
