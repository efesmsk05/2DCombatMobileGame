using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageState : PlayerState
{
    public TakeDamageState(PlayerStateMachine player) : base(player)
    {
        this.player = player;
    }
    public override void Enter()
    {
        
        Debug.Log("Player is taking damage");
    }


    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        Debug.Log("Player finished taking damage");
    }

}
