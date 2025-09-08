using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChangePhaseState : BossState
{
    private int phaseChangeTimer = 1;
    public BossChangePhaseState(Boss boss) : base(boss)
    {
        this.boss = boss;
    }
    public override void Enter()
    {
        Debug.Log("PHASEEEEEEEEEEE");
        boss.currentSkillCooldown = phaseChangeTimer;
        boss.bossIdleTimer = 0f; // Reset the idle timer
        //belli bir animasyon biti�inde idle satte ge�icez
        // bu animasyon a�amas�nda time line kullanabilir�z ses ve kamera efcts i�in
        //player haraket k�s�tlamalar�da yap�labilir
        boss.ChangeState(new BossIdleState(boss));
    }

    public override void Update()
    {
    }


    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {
        Debug.Log("Boss is exiting phase state.");
    }
}
