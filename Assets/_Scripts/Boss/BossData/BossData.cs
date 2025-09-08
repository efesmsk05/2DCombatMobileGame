using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Boss/Data")]
public class BossData : ScriptableObject
{
    public string bossName; // Name of the boss
    public int maxHealth; // Health of the boss

    public int currentPhaseIndex = 0; // Current phase index
    //e�er boss phases de�i�irse, bu index de�i�ecek

    public List<BossPhases> phases; // List of boss phases

    //boss phases
}
