using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private PlayerStateMachine player;


    public void Initialize(PlayerStateMachine player)
    {
        this.player = player;
    }

    public void OnAttackAnimationEnd()
    {
        player.ChangeState(new IdleState(player));
        player.inputHandler.ResetInputFlags();
        player.isAttacking = false;

    }




}
