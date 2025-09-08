using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboInputHandler : MonoBehaviour
{
    public SkillDatabase skillDatabase;
    public PlayerStateMachine player;

    public SkillData currentSkill;

    public List<AttackInputType> currentCombo = new List<AttackInputType>();
    private float comboResetTime = .5f; // Komboyu sıfırlamak için süre
    private float currentTimer;


    void Update()
    {
        if (player.currentState is SkillCastState) return;

        if (player.inputHandler.lightAttackTriggered)
        {
            HandleLightAttack();
            player.inputHandler.ResetInputFlags();
        }
        else if (player.inputHandler.heavyAttackTriggered)
        {
            HandleHeavyAttack();
            player.inputHandler.ResetInputFlags();
        }

        if (currentCombo.Count > 0)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                currentCombo.Clear();
                Debug.Log("Combo reset!");
            }
        }

    }

    public void AddInput(AttackInputType input)
    {
        currentCombo.Add(input);

        currentTimer = comboResetTime; 

        SkillData foundSkill = skillDatabase.GetSkillByCombo(currentCombo);

        if(foundSkill != null)
        {
            currentSkill = foundSkill;
            Debug.Log("Combo Skill Found: " + foundSkill.skillName);
            player.ChangeState(new SkillCastState(player , foundSkill));
            currentCombo.Clear(); // Komboyu temizle, skill kullanıldıktan sonra
        }


    }

    void HandleLightAttack()
    {
        if (player.currentState is SkillCastState) return;

        // Combo'ya ekle
        currentCombo.Add(AttackInputType.Light);
        currentTimer = comboResetTime;

        // Combo eşleşmesi kontrolü
        SkillData comboSkill = skillDatabase.GetSkillByCombo(currentCombo);

        if (comboSkill != null)
        {
            currentSkill = comboSkill;

            Debug.Log("Combo Skill Found: " + comboSkill.skillName);
            player.ChangeState(new SkillCastState(player, comboSkill));
            currentCombo.Clear(); // combo zincirini sıfırla
            return;
        }

        // Combo olmadıysa default light attack oynat
        SkillData defaulLighttSkill = skillDatabase.GetDefaultSkill(AttackInputType.Light);

        if (defaulLighttSkill != null)
        {
            currentSkill = defaulLighttSkill;

            defaulLighttSkill.Execute(player); // Skill'i uygula

            Debug.Log("Default Light Skill Used: " + defaulLighttSkill.skillName);
            player.ChangeState(new SkillCastState(player, defaulLighttSkill));
        }


    }

    public void HandleHeavyAttack()
    {
        if (player.currentState is SkillCastState) return;

        // Combo'ya ekle
        currentCombo.Add(AttackInputType.Heavy);
        currentTimer = comboResetTime;

        SkillData comboSkill = skillDatabase.GetSkillByCombo(currentCombo);

        if (comboSkill != null)
        {
            currentSkill = comboSkill;

            Debug.Log("Combo Skill Found: " + comboSkill.skillName);
            player.ChangeState(new SkillCastState(player, comboSkill));
            currentCombo.Clear(); // combo zincirini sıfırla
            return;
        }

        // Combo olmadıysa default light attack oynat
        SkillData defaultHeavyAttack = skillDatabase.GetDefaultSkill(AttackInputType.Heavy);

        if (defaultHeavyAttack != null)
        {
            currentSkill = defaultHeavyAttack;

            Debug.Log("Default Light Skill Used: " + defaultHeavyAttack.skillName);
            player.ChangeState(new SkillCastState(player, defaultHeavyAttack));
        }

    }



}
