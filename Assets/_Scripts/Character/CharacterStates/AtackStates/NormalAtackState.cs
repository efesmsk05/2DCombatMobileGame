using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAtackState : PlayerState
{
    public NormalAtackState(PlayerStateMachine player) : base(player) {}





    public override void Enter()
    {
        Debug.Log("Entering Normal Attack State");

        player.animator.SetBool("NormalAttack", true);

        //Debug.Log("Normal Attack State Entered");
        player.isAttacking = true;



    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {



    }

    public override void Exit()
    {
        //Debug.Log("Normal Attack State Exited");
        Debug.Log("Exiting Normal Attack State");
        player.animator.SetBool("NormalAttack", false); // Set the attack animation trigger


        // Reset input flags to prevent immediate re-triggering



    }


}
