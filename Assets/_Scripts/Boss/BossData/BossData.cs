using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Boss/Data")]
public class BossData : ScriptableObject
{
    public string bossName; // Name of the boss
    public int maxHealth; // Health of the boss

    public int currentPhaseIndex = 0; // Current phase index
    //eðer boss phases deðiþirse, bu index deðiþecek

    public List<BossPhases> phases; // List of boss phases

    //boss phases
}
