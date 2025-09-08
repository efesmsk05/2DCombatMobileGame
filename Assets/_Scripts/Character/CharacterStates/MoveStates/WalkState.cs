using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    float horizontalInput; // Yatay hareket giri�i
    float verticalInput; // Dikey hareket giri�

    float idleTimer = 0f;
    float idleDelay = 0.1f; // 100ms kadar bir sabitlik varsa idle'a ge�sin


    public WalkState(PlayerStateMachine player) : base(player) { }
    public override void Enter()
    {

        //Debug.Log("Entering walk State");
        player.animator.SetBool("Run" , true); // Y�r�y�� animasyonunu ba�lat
    }

    public override void Update()
    {

        player.SpriteFlipRotation();

        // E�er input yoksa idle state�e ge�


        //if(player.inputHandler.isAttacking())
        //{
        //    player.ChangeState(new NormalAtackState(player)); // Sald�r� durumuna ge�
        //}

        if (player.inputHandler.isJumping() && player.IsGrounded())
        {
            player.ChangeState(new JumpState(player));
        }

        if (Mathf.Abs(horizontalInput) < 0.05f)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleDelay)
            {
                player.ChangeState(new IdleState(player));
            }
        }
        else
        {
            idleTimer = 0f;
        }


    }

    public override void FixedUpdate()
    {
        horizontalInput = player.inputHandler.moveInput.x;


        float targetSpeed = horizontalInput * player.playerStatsManager.moveSpeed; // Hedef h�z
        float currentSpeed = Mathf.MoveTowards(player.rb.velocity.x, targetSpeed, player.walkAcceleration * Time.fixedDeltaTime); // Mevcut h�z

        player.rb.velocity = new Vector2(targetSpeed, player.rb.velocity.y); // Yaln�zca yatay h�z� g�ncelle

    }

    public override void Exit()
    {
        //Debug.Log("Exiting walk State");
        player.animator.SetBool("Run", false); // Y�r�y�� animasyonunu ba�lat

    }
}
