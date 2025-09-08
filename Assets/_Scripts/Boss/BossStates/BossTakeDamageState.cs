using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDamageState : BossState
{
    private float damage;
    public BossTakeDamageState(Boss boss, float damage) : base(boss)
    {
        this.boss = boss;
        this.damage = damage;
    }
    public override void Enter()
    {

        boss.TakeDamage(damage);

        boss.animator.SetBool("TakeDamage" , true);


    }

    public override void Update()
    {
    }


    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        boss.animator.SetBool("TakeDamage", false);

    }
}
