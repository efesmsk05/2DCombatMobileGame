using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{
    float idleTime;
    float timer;
    public BossIdleState(Boss boss) : base(boss)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        idleTime = boss.currentSkillCooldown; // Set idle time to the current skill cooldown
        //Debug.Log("Boss is entering idle state.");
        boss.animator.SetBool("Idle", true);
        boss.ChangePhase(boss); // Change the boss phase if needed

    }

    public override void Update()
    {
        boss.getPlayerDirection();

        boss.bossIdleTimer += Time.deltaTime; // Increment the idle timer

        if (boss.bossIdleTimer >= idleTime)
        {
            boss.bossIdleTimer = 0f; // Reset the idle timer
            boss.ChangeState(new BossSkillCastState(boss));
        }

    }

        
    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        //Debug.Log("Boss is exiting idle state.");
        boss.animator.SetBool("Idle", false);

    }

}
