using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerStasData playerStatsData;
    [SerializeField] private PlayerStateMachine player;
    [SerializeField] private UiManager uiManager;

    public float currentHealth { get; private set; }

    public float maxHealth => playerStatsData.maxHealth;
    public float attackPower => playerStatsData.attackPower;
    public float defense => playerStatsData.defense;
    public float moveSpeed => playerStatsData.moveSpeed;

    void Start()
    {
        currentHealth = playerStatsData.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(CameraShake.Instance.Shake(0.10f, 0.05f));

        float effectiveDamage = Mathf.Max(damage - defense, 0);

        uiManager.UpdatePlayerHealthBar(effectiveDamage , maxHealth); // Update the health bar in UI

    }

    private void Die()
    {
        Debug.Log("Player has died.");
        //PlayerStateMachine.ChangeState(PlayerStateMachine.deathState);
        // Implement death logic here, such as playing an animation or restarting the level
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

}
