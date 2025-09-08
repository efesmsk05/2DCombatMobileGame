using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private Enemy enemy; // Reference to the Enemy class
    public BossTypes bossType; // Reference to the BossTypes ScriptableObject

    public int currentHealth; // Current health of the enemy
    public string bossName; // Maximum health of the enemy

    public void Initilaize(Enemy enemy)
    {
        this.enemy = enemy; // Initialize the enemy reference
    }
    private void Awake()
    {
        if (bossType != null)
        {
            currentHealth = bossType.bossMaxHealth; // Initialize current health from the ScriptableObject
            bossName = bossType.bossName; // Initialize boss name from the ScriptableObject
        }
        else
        {
            Debug.LogError("BossTypes ScriptableObject is not assigned in EnemyStats.");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by the damage amount
        Debug.Log("boss hasar aldý " + "-" + damageAmount);

        currentHealth = Mathf.Max(0, currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log($"{bossName} has been defeated!");
        }
    }

    public void ResetStats()
    {

        currentHealth = bossType.bossMaxHealth; // Reset current health to maximum health
    }


}
