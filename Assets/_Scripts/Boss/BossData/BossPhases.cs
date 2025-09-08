using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Boss/Phases")]
public class BossPhases : ScriptableObject
{
    public int phaseChangeHealth; 
    public List<BossSkill> skills;
}
