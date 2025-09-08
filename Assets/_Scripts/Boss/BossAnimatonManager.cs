using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatonManager : MonoBehaviour
{
    private Boss boss;
    public bool isAnimationFinished = false;
    public void Intilaize(Boss boss)
    {
        this.boss = boss;
    }

    public void DamageTaked()
    {
        boss.ChangeState(new BossIdleState(boss));
    }


    public void Died()
    {
        this.boss.gameObject.SetActive(false);
    }

    public void PhaseChange()
    {

    }// phase change animation event 

    public void OnAnimationFinished()
    {
        isAnimationFinished = true;
    }



}
