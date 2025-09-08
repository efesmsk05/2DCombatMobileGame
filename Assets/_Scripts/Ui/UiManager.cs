using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro; // DOTween kütüphanesini ekleyin

public class UiManager : MonoBehaviour
{
    [Header("GameOver UÝ")]
    public CanvasGroup gameOverCanvasGroup; // Game Over UI Canvas Group

    [Header ("Boss Defeated UÝ")]
    public CanvasGroup bossDefeatCanvas; // Game Over UI Canvas Group




    [Header("Health Bar Settings")]
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;

    [Header("Boss Health Bar Settings")]
    public Image bossbHealthBar;
    public float bossMaxHealth;

    [Header ("Damage Counter")]
    public TextMeshProUGUI damageCounterText;




    private void Start()
    {
        maxHealth = 100; // Standart health
        currentHealth = maxHealth;
    }

    public void UpdateDamageCount(int damaeCount)
    {
        damageCounterText.text  = "X " + damaeCount;
    }
        

    public void UpdateBossHealthBar(float MaxHealth , float currentHealth)
    {
        bossMaxHealth = MaxHealth; // Set the maximum health for the boss
        float CurrentBarHeath = (float)currentHealth / MaxHealth; // Calculate the current health percentage
        if (bossbHealthBar != null)
        {
            bossbHealthBar.fillAmount = CurrentBarHeath; // Update the boss health bar fill amount
        }
    }

    public void UpdatePlayerHealthBar(float damage , float maxHealth)
    {
        print("UpdatePlayerHealthBar called with damage: " + damage + " and maxHealth: " + maxHealth);
        this.maxHealth = maxHealth; // Set the maximum health


        if (currentHealth != 0) // Check if the player is already dead
        {
            currentHealth -= damage;

            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            float currentBarHealth = currentHealth / maxHealth; // Calculate the current health percentage

            if (healthBar != null)
            {
                healthBar.fillAmount = currentBarHealth; // Update the health bar fill amount
            }
        }
        if (currentHealth <= 0) // Check if the player is dead
        {
            GameOver(); // Call the GameOver method if the player is dead
            return; // Exit the method to prevent further processing
        }






    }

    public void ResetHealthBar()
    {
        currentHealth = maxHealth; // Reset current health to max health

    }

    public void GameOver()
    {
        Debug.Log("Game Over!"); // Placeholder for game over logic
        Time.timeScale = 0.07f; // Stop the game time
        gameOverCanvasGroup.alpha = 0f;
        gameOverCanvasGroup.gameObject.SetActive(true);
        gameOverCanvasGroup.DOFade(1f, 1f).SetUpdate(true); // DOTween ile fade-in efekti
    }

    public void BossDefeated()
    {
        Debug.Log("Game Over!"); // Placeholder for game over logic
        Time.timeScale = 0.07f; // Stop the game time
        bossDefeatCanvas.alpha = 0f;
        bossDefeatCanvas.gameObject.SetActive(true);
        bossDefeatCanvas.DOFade(1f, 1f).SetUpdate(true); // DOTween ile fade-in efekti
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }



}
