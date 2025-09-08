using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageState : EnemyState
{

    public EnemyTakeDamageState(Enemy enemy) : base(enemy) // Constructor to initialize the enemy reference
    {
    }
    public override void Enter()
    {
        Debug.Log("Enemy has entered Take Damage State");
        enemy.animator.SetBool("TakeDamage", true); // Trigger the TakeDamage animation
    }
    public override void Update()
    {
    }
    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        Debug.Log("Enemy has exited Take Damage State");
        enemy.animator.SetBool("TakeDamage",false); // Reset the TakeDamage trigger
    }
}
