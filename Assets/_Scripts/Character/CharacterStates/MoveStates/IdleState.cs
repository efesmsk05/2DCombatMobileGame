using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    //public IdleState(PlayerStateMachine player) : base(player)
    //{
    //    // Constructor logic if needed
    //}

    public IdleState(PlayerStateMachine player) : base(player) { }
    public override void Enter()
    {
        //Debug.Log("Entering Idle State");
        if (player.inputHandler.isMoving())
        {
            player.ChangeState(new WalkState(player)); // Change to MoveState if moving
        }
        else
        {
            player.animator.SetBool("Idle", true); // Set the idle animation trigger

        }


    }

    public override void Update()
    {
        player.SpriteFlipRotation();



    }

    public override void FixedUpdate()
    {

        if (player.inputHandler.isMoving())
        {
            player.ChangeState(new WalkState(player)); // Change to MoveState if moving
        }

        if (player.inputHandler.isJumping())
        {
            Debug.Log("is jumping");
            player.ChangeState(new JumpState(player)); // Change to JumpState if jumping
        }

        //if (player.inputHandler.isAttacking() && player.IsGrounded() && !player.isAttacking)
        //{
        //    if (!(player.currentState is NormalAtackState))
        //    {
        //        player.ChangeState(new NormalAtackState(player));
        //    }
        //}
    }

    public override void Exit()
    {
        player.animator.SetBool("Idle", false); // Set the idle animation trigger

    }
}
