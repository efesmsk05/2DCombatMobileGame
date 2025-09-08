using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :MonoBehaviour
{
    public static Enemy instance; // Singleton instance of the Enemy class
    public EnemyState currentState { get; private set; } // Current state of the enemy

    [Header("Enemey Referances")]
    private Rigidbody2D enemyRb;
    public EnemyStats enemyStats; // Reference to the EnemyStats scriptable object
    public Animator animator;
    public EnemyAnimatiomController enemyAnimatiomController; // Reference to the EnemyAnimatiomController script

    private void Awake()
    {
        instance = this; // Set the singleton instance
        enemyStats.Initilaize(this); // Initialize the EnemyStats with this enemy instance
        enemyAnimatiomController.Initialize(this); 
        enemyRb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the enemy
    }


    private void Start()
    {
        ChangeState(new EnemyIdleState(this)); // Initialize with the Idle state
    }


    private void Update()
    {
        currentState?.Update(); // Update the current state if it exists
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdate(); // Fixed update for physics-related updates
    }

    public void ChangeState(EnemyState newState)
    {
        currentState?.Exit(); // Exit the current state if it exists
        currentState = newState; // Set the new state
        currentState.Enter(); // Enter the new state
    }


    // iþlevsellik eklenebilir, örneðin düþman hareketi, saldýrý, hasar alma gibi fonksiyonlar

    public void TakeDamage(int damage)
    {
        // can azalýr ve satte deðiþtirir
        
        enemyStats.TakeDamage(damage); // Call the TakeDamage method from EnemyStats with a damage amount of 1
        ChangeState(new EnemyTakeDamageState(this)); // Change to the Take Damage state


    }

}


