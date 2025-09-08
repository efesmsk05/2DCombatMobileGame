using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Skill System/Skill Database")]
public class SkillDatabase : ScriptableObject
{
    public List<SkillData> allSkills;

    // Bu metod, spesifik bir combo pattern'e karþýlýk gelen skilli bulur
    public SkillData GetSkillByCombo(List<AttackInputType> inputCombo)
    {
        foreach (SkillData skill in allSkills)
        {
            if (!skill.isComboSkill) continue; // 
            if (skill.inputPattern.Length != inputCombo.Count)
                continue;

            bool match = true;
            for (int i = 0; i < inputCombo.Count; i++)
            {
                if (skill.inputPattern[i] != inputCombo[i])
                {
                    match = false;
                    break;
                }
            }

            if (match)
                return skill;
        }

        return null;
    }



    public SkillData GetDefaultSkill(AttackInputType inputType)
    {
        return allSkills.FirstOrDefault(s =>
            s.isDefaultSkill &&
            !s.isComboSkill && // 
            s.inputPattern != null &&
            s.inputPattern.Length == 1 &&
            s.inputPattern[0] == inputType);
    }
}
