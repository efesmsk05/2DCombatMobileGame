using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(PlayerStateMachine player) : base(player) { }

    private float jumpStartTime;
    private float minJumpDuration = 0.2f; // 100 ms

    private float horizontalInput; // Yatay hareket giriþi

    private float airSpeed = 0.5f; // Hava hýzýný kontrol etmek için kullanýlabilir
    public override void Enter()
    {

        // animasyonun 

        player.animator.SetBool("Jump", true); // Atlama animasyonunu baþlat


        //
        //Debug.Log("Entering Jump State");
        jumpStartTime = Time.time;

        Vector2 jumpForce;
        if(player.inputHandler.moveInput.x != 0 )
        {
            airSpeed = 1.35f; // Hava hýzýný artýr
        }
        else
        {
            airSpeed = 0.8f; // Hava hýzýný normalde tut
        }
            jumpForce = new Vector2(0f, player.jumpForce); // Y ekseninde yukarý doðru kuvvet
        player.rb.AddForce(jumpForce, ForceMode2D.Impulse);

        player.inputHandler.ResetInputFlags();
    }


    public override void Update()
    {
        player.SpriteFlipRotation();

        horizontalInput = player.inputHandler.moveInput.x;


        // Minimum süre geçmeden yere temas kontrolü yok
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
        //    player.ChangeState(new NormalAtackState(player)); // Saldýrý durumuna geç
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
        player.animator.SetBool("Jump", false); // Atlama animasyonunu baþlat

        //Debug.Log("Exiting Jump State");
    }
}
