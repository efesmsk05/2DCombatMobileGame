using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(PlayerStateMachine player) : base(player) { }

    private float jumpStartTime;
    private float minJumpDuration = 0.2f; // 100 ms

    private float horizontalInput; // Yatay hareket giri�i

    private float airSpeed = 0.5f; // Hava h�z�n� kontrol etmek i�in kullan�labilir
    public override void Enter()
    {

        // animasyonun 

        player.animator.SetBool("Jump", true); // Atlama animasyonunu ba�lat


        //
        //Debug.Log("Entering Jump State");
        jumpStartTime = Time.time;

        Vector2 jumpForce;
        if(player.inputHandler.moveInput.x != 0 )
        {
            airSpeed = 1.35f; // Hava h�z�n� art�r
        }
        else
        {
            airSpeed = 0.8f; // Hava h�z�n� normalde tut
        }
            jumpForce = new Vector2(0f, player.jumpForce); // Y ekseninde yukar� do�ru kuvvet
        player.rb.AddForce(jumpForce, ForceMode2D.Impulse);

        player.inputHandler.ResetInputFlags();
    }


    public override void Update()
    {
        player.SpriteFlipRotation();

        horizontalInput = player.inputHandler.moveInput.x;


        // Minimum s�re ge�meden yere temas kontrol� yok
        if (Time.time - jumpStartTime < minJumpDuration)
            return;

        if (player.IsGrounded() && player.inputHandler.moveInput.y == 0)
        {
            if (Mathf.Abs(horizontalInput) > 0.1f)
                player.ChangeState(new WalkState(player));
            else
                player.ChangeState(new IdleState(player));
        }

        //if(!player.IsGrounded() && player.inputHandler.isAttacking())
        //{
        //    player.ChangeState(new NormalAtackState(player)); // Sald�r� durumuna ge�
        //}
    }

    public override void FixedUpdate()
    {

        Vector2 velocity = player.rb.velocity;
        velocity.x = horizontalInput * player.playerStatsManager.moveSpeed * airSpeed;
        player.rb.velocity = velocity;
    }

    public override void Exit()
    {
        player.animator.SetBool("Jump", false); // Atlama animasyonunu ba�lat

        //Debug.Log("Exiting Jump State");
    }
}
