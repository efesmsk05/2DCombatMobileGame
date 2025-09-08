using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCastState : PlayerState
{

    private SkillData currentSkill;

    float horizontalInput; // Yatay hareket girişi

    private float groundDirectionSpeed = 0.2f; // Saldırı sırasında hareket hızı
    private float airDirectionSpeed = 0.7f; // Saldırı sırasında hareket hızı

    public float directionSpeedReverse = -0.35f; // Ters yönde hareket hızı


    public SkillCastState(PlayerStateMachine player, SkillData skill) : base(player)
    {
        this.currentSkill = skill;
    }


    public override void Enter()
    {
        Debug.Log("Entering SkillCast State");

        if (player.inputHandler.moveInput.x != 0) // input varmı 
        {
            groundDirectionSpeed = 1;
            airDirectionSpeed = .7f;

        }
        else
        {
            groundDirectionSpeed = 1;
            airDirectionSpeed = .1f;

        }


        if (currentSkill.animationClip != null)
        {
            player.SetAnimation(currentSkill.animationClip); // Skill animasyonunu ayarla
            player.animator.SetBool("Attack", true); // Saldırı animasyonunu başlat
            player.StartCoroutine(CastSkillCoroutine()); // Coroutine'i doğru şekilde başlat
        }
    }

    private IEnumerator CastSkillCoroutine()
    {
        float duration = currentSkill.animationClip != null ? currentSkill.animationClip.length : 0.5f;

        yield return new WaitForSeconds(duration);

        player.animator.SetBool("Attack", false); // Animasyon bitince saldırı flag'ini kapat

        player.ChangeState(new IdleState(player));
    }



    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
        horizontalInput = player.inputHandler.moveInput.x;
        float attackDirection = player.spriteRenderer.flipX ? -1f : 1f;


        if (currentSkill.skillMovementType == SkillMovementType.Deafult)
        {
            if (!player.IsGrounded())
            {
                player.SpriteFlipRotation();

            }


            if (horizontalInput == -attackDirection) // ters yönde hareket ediyorsa
            {

                //ters yöne geçme animasyonu koyulabilir 
                //player.SetAnimation(currentSkill.animationClip); // Skill animasyonunu ayarla ufak bir flip animation koyulabilri skillere özel
                // bu sebeplede bazı skillere alternaatif aniasmyonlar koyulabilişr

                Debug.Log("Ters yönde hareket ediliyor.");

                float targetSpeed = attackDirection * player.playerStatsManager.moveSpeed * .20f;
                player.rb.velocity = new Vector2(targetSpeed, player.rb.velocity.y);

                player.SpriteFlipRotation();

            }
            else if (horizontalInput == attackDirection) // normal yönde hareket ediyorsa
            {
                float targetSpeed = horizontalInput * player.playerStatsManager.moveSpeed * .65f; // Hedef hız

                player.rb.velocity = new Vector2(targetSpeed, player.rb.velocity.y); // Yalnızca yatay hızı güncelle
            }


        }
        else if (currentSkill.skillMovementType == SkillMovementType.Limited)
        {

            Debug.Log("Limited");
            float targetSpeed = horizontalInput * player.playerStatsManager.moveSpeed * .10f; // Hedef hız

            player.rb.velocity = new Vector2(targetSpeed, player.rb.velocity.y); // Yalnızca yatay hızı güncelle


        }

        if (player.IsGrounded() && player.inputHandler.isJumping())
        {
            player.ChangeState(new JumpState(player)); // Zıplama durumuna geç
        }

    }

    public override void Exit()
    {

    }
}
