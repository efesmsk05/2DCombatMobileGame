public abstract class PlayerState
{
    protected PlayerStateMachine player;

    public PlayerState(PlayerStateMachine player)
    {
        this.player = player;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
}
