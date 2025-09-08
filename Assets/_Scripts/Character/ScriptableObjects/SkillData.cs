using System.Collections; // IEnumerator için gerekli
using UnityEngine;




[CreateAssetMenu(menuName = "Combat/Skill")]
public class SkillData : ScriptableObject
{

    public string skillName;

    public AnimationClip animationClip;

    public float damage;
    public float cooldown;

    public float hitboxOffsetX = 0.0f; // Hitbox'un X eksenindeki ofseti
    public Vector2 hitboxSize = new Vector2(1.03f, 1.57f); 

    public SkillMovementType skillMovementType = SkillMovementType.Deafult; // Default, Limited veya Special
    public SkillType skillType; // Default veya Combo

    public SkillExecute skillExecute; 

    public AttackInputType[] inputPattern; // boþsa bu skill combo deðil normal bir skill

    public bool isComboSkill => skillType == SkillType.Combo;
    public bool isDefaultSkill => skillType == SkillType.Default;

    public bool isLimitedSkill => skillMovementType == SkillMovementType.Limited;

    public bool isSpecialSkill => skillMovementType == SkillMovementType.Special;

    public bool isDeafultSkill => skillMovementType == SkillMovementType.Deafult;

    private Coroutine activeCoroutine;

    public void Execute(PlayerStateMachine player)
    {
        if (activeCoroutine != null)
            player.StopCoroutine(activeCoroutine); // Önceki coroutine’i durdur

        activeCoroutine = player.StartCoroutine(ExecuteRoutine(player));
    }

    private IEnumerator ExecuteRoutine(PlayerStateMachine player)
    {
        yield return player.StartCoroutine(skillExecute.Execute(player));
        // hepsi bittikten sonra idle state'e geri dön
        //boss.ChangeState(new BossIdleState(boss));

    }
 }

