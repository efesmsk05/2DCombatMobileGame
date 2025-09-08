using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    public EnemyIdleState(Enemy enemy) : base(enemy) // Constructor to initialize the enemy reference
    {
    }
    public override void Enter() 
    {
        Debug.Log("Enemy has entered Idle State");
        enemy.animator.SetBool("Idle", true); 
    }
    public override void Update() 
    {
    }
    public override void FixedUpdate()
    {
    }
    public override void Exit() 
    {
        enemy.animator.SetBool("Idle", false);

    }
}
