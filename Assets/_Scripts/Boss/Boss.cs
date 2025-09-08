using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    BossState currentState;

    [Header ("boss stats")]
    private float currentHealth; // Current health of the boss
    private int currentStamina; // Current stamina of the boss
    public int currentSkill;
    public int currentSkillCooldown = 2;
    public float bossIdleTimer;
    public int takedDamageCount = 0; 
    private float lastDamageTime = 0f;

    [Header("Boss Source Referances")]
    public PlayerStateMachine player; 
    public Sprite bossSprite;
    public UiManager uiManager; 
    public Animator animator;
    public AnimatorOverrideController baseOverrideController;
    public BossAnimatonManager bossAnimatonManager;
    public SpriteRenderer spriteRenderer; 
    //public Transform target; // Target for the boss to follow or attack
    public Rigidbody2D rb;
    public GameObject bossAttackHitbox;

    public List<BossData> bossData;

    private void Awake()
    {
        bossAnimatonManager.Intilaize(this); // Initialize the boss animation manager
    }

    private void Start()
    {
        currentHealth = bossData[0].maxHealth;
        bossData[0].currentPhaseIndex = 0;

        ChangeState(new BossIdleState(this));

        print(currentHealth);
    }

    private void Update()
    {
        currentState?.Update();
        damageCount(); 

    }

    private void FixedUpdate()
    {

        currentState?.FixedUpdate(); 
    }

    public void ChangeState(BossState newState)
    {
        if (currentState != null)
        {
            currentState.Exit(); // Exit the current state
        }
        
        currentState = newState; // Set the new state
        currentState.Enter(); // Enter the new state


    }


    public void ExecuteRandomSkill(Boss boss)
    {
        if (boss.bossData.Count > 0 && boss.bossData[0].phases.Count > 0)
        {
            var currentPhaseIndex = boss.bossData[0].currentPhaseIndex;
            var phaseList = boss.bossData[0].phases;
            if (currentPhaseIndex>= 0 && currentPhaseIndex < phaseList.Count)// pahse varmý kontrolü
            {
                var skills = phaseList[currentPhaseIndex].skills;// skill referansý alýp sürekli olarak kontrol ediyorum ve yol kýsalýyoruz bir bakýma
                if (skills != null && skills.Count > 0)
                {
                    Debug.Log("current Phase : " + currentPhaseIndex);
                    int randomSkillIndex = Random.Range(0, skills.Count);
                    currentSkillCooldown = skills[randomSkillIndex].cooldown; 
                    skills[randomSkillIndex].Execute(boss);

                    currentSkill = randomSkillIndex; 

                }
                else
                {
                    Debug.LogWarning("Seçilen fazda skill yok.");
                }
            }
            else
            {
                Debug.LogWarning("Geçersiz faz indexi.");
            }
        }
        else
        {
            Debug.LogWarning("BossData veya faz listesi boþ.");
        }
    }

    public void ChangePhase(Boss boss)
    {
        if (boss.bossData.Count > 0 && boss.bossData[0].phases.Count > 0)
        {
            var currentPhaseIndex = boss.bossData[0].currentPhaseIndex;
            var phaseList = boss.bossData[0].phases;
            var phaseCount = phaseList.Count;


            if (currentPhaseIndex >= 0 && currentPhaseIndex < phaseList.Count)// phase kontrol
            {

                if (currentHealth < phaseList[currentPhaseIndex].phaseChangeHealth)
                {
                    //change phase
                    currentPhaseIndex++;
                    if (currentPhaseIndex < phaseCount)
                    {
                        boss.bossData[0].currentPhaseIndex = currentPhaseIndex; // Update the current phase index


                        ChangeState(new BossChangePhaseState(boss));
                    }
                    else
                    {
                        Debug.Log("No more phases available.");
                    }

                }
            }
        }
;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage; // Reduce current health by the damage amount
            uiManager.UpdateBossHealthBar(bossData[0].maxHealth, currentHealth); // Update the health bar in UI
            Debug.Log("Boss took damage: " + damage + ". Current health: " + currentHealth);


            takedDamageCount++; // Increment the damage count
            uiManager.UpdateDamageCount(takedDamageCount); // Update the damage count in UI

            lastDamageTime = Time.time; // Update the last damage time

            if (currentHealth <= 2)
            {
                Debug.Log("Boss has been defeated!");
                ChangeState(new BossDieState(this)); // Change to defeated state
            }
        }

    }

    public void getPlayerDirection()
    {
        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false; // Face right

            Vector3 hitboxLocalPos = bossAttackHitbox.transform.localPosition;
            hitboxLocalPos.x = Mathf.Abs(hitboxLocalPos.x);
            bossAttackHitbox.transform.localPosition = hitboxLocalPos;

        }
        else
        {
            spriteRenderer.flipX = true; // Face left

            Vector3 hitboxLocalPos = bossAttackHitbox.transform.localPosition;
            hitboxLocalPos.x = -Mathf.Abs(hitboxLocalPos.x);
            bossAttackHitbox.transform.localPosition = hitboxLocalPos;
        }
    }

    public void damageCount()
    {
        if (takedDamageCount > 0)
        {
            if (Time.time - lastDamageTime > 2f)
            {
                print("SÜREN BÝTTÝ");
                takedDamageCount = 0; // Reset if no new damage is taken for 2 seconds
                uiManager.UpdateDamageCount(takedDamageCount); // Update the damage count in UI

            }
        }
    }

    public void SetAnimation(AnimationClip animation)
    {
        if (animator.runtimeAnimatorController is AnimatorOverrideController currentOverride)
        {
            currentOverride["bossAttack"] = animation;
        }
        else
        {
            AnimatorOverrideController newOverride = new AnimatorOverrideController(baseOverrideController);
            newOverride["bossAttack"] = animation;
            animator.runtimeAnimatorController = newOverride;
        }

        // Ayný state olsa bile yeniden baþlamasýný ZORLA
        animator.Play("Attack", -1, 0f);
    }





}

