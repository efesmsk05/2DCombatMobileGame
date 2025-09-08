using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Skill/SkillExecute")]

public class LightAttack : SkillExecute
{
    public override IEnumerator Execute(PlayerStateMachine player)
    {
        // Light attack execution logic
        Debug.Log("Executing light attack");
        
        // Simulate some delay for the attack animation or effect
        yield return new WaitForSeconds(0.5f);
        
        // Logic to apply damage or effects to the target
        // For example: player.ApplyDamage(target, damageAmount);
        
        Debug.Log("Light attack executed successfully");
    }
}
