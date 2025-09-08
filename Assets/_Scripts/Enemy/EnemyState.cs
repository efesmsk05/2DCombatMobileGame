using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState 
{
    protected Enemy enemy; // Reference to the enemy instance

    public EnemyState(Enemy enemy) // Constructor to initialize the enemy reference
    {
        this.enemy = enemy;
    }

    public abstract void Enter(); // Method to enter the enemy state
    public abstract void Update(); // Method to update the enemy state each frame
    public abstract void FixedUpdate(); // Method to update the enemy state in fixed time intervals
    public abstract void Exit(); // Method to exit the enemy state
}
