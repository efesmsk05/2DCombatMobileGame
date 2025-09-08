using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    float horizontalInput; // Yatay hareket giriþi
    float verticalInput; // Dikey hareket giriþ

    float idleTimer = 0f;
    float idleDelay = 0.1f; // 100ms kadar bir sabitlik varsa idle'a geçsin


    public WalkState(PlayerStateMachine player) : base(player) { }
    public override void Enter()
    {

        //Debug.Log("Entering walk State");
        player.animator.SetBool("Run" , true); // Yürüyüþ animasyonunu baþlat
    }

    public override void Update()
    {

        player.SpriteFlipRotation();

        // Eðer input yoksa idle state’e geç


        //if(player.inputHandler.isAttacking())
        //{
        //    player.ChangeState(new NormalAtackState(player)); // Saldýrý durumuna geç
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


        float targetSpeed = horizontalInput * player.playerStatsManager.moveSpeed; // Hedef hýz
        float currentSpeed = Mathf.MoveTowards(player.rb.velocity.x, targetSpeed, player.walkAcceleration * Time.fixedDeltaTime); // Mevcut hýz

        player.rb.velocity = new Vector2(targetSpeed, player.rb.velocity.y); // Yalnýzca yatay hýzý güncelle

    }

    public override void Exit()
    {
        //Debug.Log("Exiting walk State");
        player.animator.SetBool("Run", false); // Yürüyüþ animasyonunu baþlat

    }
}
