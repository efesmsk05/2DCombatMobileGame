using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState
{
    protected Boss boss; // Reference to the boss instance

    public BossState(Boss boss)
    {
        this.boss = boss; // Initialize the boss reference
    }
    abstract public void Enter(); // Called when the boss state is entered
    abstract public void Update(); // Called every frame while in the boss state
    abstract public void FixedUpdate(); // Called every fixed frame-rate frame while in the boss state
    abstract public void Exit(); // Called when the boss state is exited
}
